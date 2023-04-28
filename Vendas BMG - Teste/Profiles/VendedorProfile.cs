using AutoMapper;
using VendasBMGTeste.Domain.Models;
using VendasBMGTestes.Application.Dtos;

public class VendedorProfile : Profile
{
    public VendedorProfile()
    {
        CreateMap<VendedorDto, Vendedor>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
            )
            .ForMember(
                dest => dest.Cpf,
                opt => opt.MapFrom(src => $"{src.Cpf}")
            )
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome}")
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => $"{src.Email}")
            )
            .ForMember(
                dest => dest.Telefone,
                opt => opt.MapFrom(src => $"{src.Telefone}")
            )
            .ReverseMap();
    }
}