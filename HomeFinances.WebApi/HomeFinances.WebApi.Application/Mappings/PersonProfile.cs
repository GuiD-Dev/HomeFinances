using AutoMapper;
using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.Transactions, opt => opt.Ignore());
        }
    }
}
