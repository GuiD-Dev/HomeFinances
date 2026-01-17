using AutoMapper;
using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
