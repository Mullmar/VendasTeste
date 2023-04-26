using AutoMapper;
using VendasBMGTeste.Domain.Models;
using VendasBMGTestes.Application.Dtos;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<ProdutoDto, Produto>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
            )
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome}")
            ).ReverseMap();
    }
}