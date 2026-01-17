using AutoMapper;
using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Mappings
{
    public class TransactionRequestProfile : Profile
    {
        public TransactionRequestProfile()
        {
            CreateMap<TransactionRequestDto, Transaction>();
        }
    }
}
