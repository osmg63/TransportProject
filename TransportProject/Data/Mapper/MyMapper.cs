using AutoMapper;
using TransportProject.Data.Dtos.AddressDtos;
using TransportProject.Data.Dtos.JobDtos;
using TransportProject.Data.Dtos.MessageDtos;
using TransportProject.Data.Dtos.OfferDtos;
using TransportProject.Data.Dtos.UserDtos;
using TransportProject.Data.Dtos.VehicleDtos;
using TransportProject.Data.Entities;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.Mapper
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
            CreateMap<ResponseJobDto, Job>().ReverseMap();
            CreateMap<CityResponseDto, City>().ReverseMap();
            CreateMap<ResponseMessageDto, Message>().ReverseMap();
            CreateMap<RequestOfferDto, Offer>().ReverseMap();
            CreateMap<ResponseOfferDto, Offer>().ReverseMap();
            CreateMap<ResponseVehicle, Vehicle>().ReverseMap();
            CreateMap<RequestVehicle, Vehicle>().ReverseMap();



        }
    }
}
