using AutoMapper;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Data
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<User, User>().ReverseMap();
            CreateMap<RequestUserDto, User>().ReverseMap();
            CreateMap<ResponseUserDto, User>().ReverseMap();
            CreateMap<CreateJobDto, Job>().ReverseMap();
            CreateMap<CreateAddress, DepartureAddress>().ReverseMap();
            CreateMap<CreateAddress, DestinationAddress>().ReverseMap();
            CreateMap<ResponseJobDto,Job>().ReverseMap();
            CreateMap<CityResponseDto, City>().ReverseMap();
            CreateMap<ResponseMessageDto, Message>().ReverseMap();
            CreateMap<RequestOfferDto,Offer>().ReverseMap();
        }
    }
}
