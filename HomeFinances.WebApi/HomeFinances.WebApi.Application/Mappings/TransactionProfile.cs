using AutoMapper;
using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Category.Description))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name));

            CreateMap<TransactionDto, Transaction>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Person, opt => opt.Ignore());
        }
    }
}
