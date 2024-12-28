using System.Text.Json;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace TransportProject.Data.Filters
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ToFilterView<T>(this IQueryable<T> query, FilterDto filter)
        {
            // Apply filter
            query = Filter(query, filter.Filter);
            // Apply sort
            if (filter.Sort != null && filter.Sort.Any())
            {
                query = Sort(query, filter.Sort);
                // EF does not apply skip and take without order
                //   query = Limit(query, filter.Limit, filter.Offset);
            }
            // Return the final query
            return query;
        }

        private static IQueryable<T> Filter<T>(IQueryable<T> queryable, Filter filter)
        {
            if (filter != null && !string.IsNullOrEmpty(filter.Logic))
            {
                var filters = GetAllFilters(filter);
                var values = filters.Select(f => ConvertValue(f.Value)).ToArray();
                var where = Transform(filter, filters);
                queryable = queryable.Where(where, values);
            }
            return queryable;
        }

        private static IQueryable<T> Sort<T>(IQueryable<T> queryable, IEnumerable<Sort> sort)
        {
            if (sort != null && sort.Any())
            {
                var ordering = string.Join(",", sort.Select(s => $"{s.Field} {s.Dir}"));
                return queryable.OrderBy(ordering);
            }
            return queryable;
        }

        private static IQueryable<T> Limit<T>(IQueryable<T> queryable, int limit, int offset)
        {
            return queryable.Skip(offset).Take(limit);
        }

        private static readonly IDictionary<string, string> Operators = new Dictionary<string, string>
        {
            {"eq", "="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="},
            {"startswith", "StartsWith"},
            {"endswith", "EndsWith"},
            {"contains", "Contains"},
            {"doesnotcontain", "Contains"},
        };

        public static IList<Filter> GetAllFilters(Filter filter)
        {
            var filters = new List<Filter>();
            GetFilters(filter, filters);
            return filters;
        }

        private static void GetFilters(Filter filter, IList<Filter> filters)
        {
            if (filter.Filters != null && filter.Filters.Any())
            {
                foreach (var item in filter.Filters)
                {
                    GetFilters(item, filters);
                }
            }
            else
            {
                filters.Add(filter);
            }
        }

        public static string Transform(Filter filter, IList<Filter> filters)
        {
            if (filter.Filters != null && filter.Filters.Any())
            {
                return "(" + string.Join(" " + filter.Logic + " ",
                    filter.Filters.Select(f => Transform(f, filters)).ToArray()) + ")";
            }

            int index = filters.IndexOf(filter);
            var comparison = Operators.ContainsKey(filter.Operator) ? Operators[filter.Operator] : "==";

            if (filter.Operator == "doesnotcontain")
            {
                return string.Format("({0} != null && !{0}.ToString().{1}(@{2}))",
                    filter.Field, comparison, index);
            }
            if (comparison == "StartsWith" ||
                comparison == "EndsWith" ||
                comparison == "Contains")
            {
                return string.Format("({0} != null && {0}.{1}(@{2}))",
                    filter.Field, comparison, index);
            }
            return string.Format("{0} {1} @{2}", filter.Field, comparison, index);
        }

        private static object ConvertValue(object value)
        {
            if (value is JsonElement jsonElement)
            {
                switch (jsonElement.ValueKind)
                {
                    case JsonValueKind.String:
                        return jsonElement.GetString();
                    case JsonValueKind.Number:
                        return jsonElement.GetDouble();
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        return jsonElement.GetBoolean();
                    default:
                        return jsonElement.ToString();
                }
            }
            return value;
        }
    }
}

