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
                dest => dest.Status,
                opt => opt.MapFrom(src => $"{src.Status}")
            )
            .ForMember(
                dest => dest.DataPedido,
                opt => opt.MapFrom(src => $"{src.DataPedido}")
            )
            .ReverseMap();
    }
}