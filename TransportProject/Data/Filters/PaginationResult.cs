namespace TransportProject.Data.Filters
{
    public class PaginationResult<T>
    {
        public IList<T> Items { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
