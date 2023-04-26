using AutoMapper;
using VendasBMGTeste.Domain.Models;
using VendasBMGTestes.Application.Dtos;

public class VendaProfile : Profile
{
    public VendaProfile()
    {
        CreateMap<VendaDto, Venda>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
            )
            .ForMember(
                dest => dest.IdVendedor,
                opt => opt.MapFrom(src => $"{src.IdVendedor}")
            )
            .ForMember(
                dest => dest.IdStatus,
                opt => opt.MapFrom(src => $"{src.IdStatus}")
            )
            .ForMember(
                dest => dest.DataPedido,
                opt => opt.MapFrom(src => $"{src.DataPedido}")
            )
            .ReverseMap();
    }
}