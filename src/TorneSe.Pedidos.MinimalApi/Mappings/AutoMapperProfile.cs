using System.Text.Json;
using AutoMapper;
using TorneSe.Pedidos.MinimalApi.Domain.Constants;
using TorneSe.Pedidos.MinimalApi.Domain.Entities;
using TorneSe.Pedidos.MinimalApi.Domain.Enums;
using TorneSe.Pedidos.MinimalApi.Domain.Messages;
using TorneSe.Pedidos.MinimalApi.Infraestrutura.Models;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Request;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Response;

namespace TorneSe.Pedidos.MinimalApi.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        PedidoCriadoMappers();
    }

    private void PedidoCriadoMappers()
    {
        CreateMap<PedidoItemRequest, PedidoItem>()
            .ReverseMap();

        CreateMap<PedidoFormaPagamentoRequest, FormaPagamento>()
            .ReverseMap();

        CreateMap<CriarPedidoRequest, Pedido>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.DataPedido, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusPedido.Pendente))
            .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens))
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => new Cliente
            {
                Id = src.IdCliente,
                Nome = src.Nome,
                Email = src.Email,
                Telefone = src.Telefone,
                Endereco = new Endereco
                {
                    Logradouro = src.Logradouro,
                    Numero = src.Numero,
                    Complemento = src.Complemento,
                    Bairro = src.Bairro,
                    Cidade = src.Cidade,
                    Estado = src.Estado,
                    Cep = src.Cep
                }
            }))
            .ForMember(dest => dest.EnderecoEntrega, opt => opt.MapFrom(src => new Endereco
            {
                Logradouro = src.Logradouro,
                Numero = src.Numero,
                Complemento = src.Complemento,
                Bairro = src.Bairro,
                Cidade = src.Cidade,
                Estado = src.Estado,
                Cep = src.Cep
            }));

        CreateMap<Pedido, PedidoDynamoModel>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
           .ForMember(dest => dest.DataPedido, opt => opt.MapFrom(src => src.DataPedido.ToString("yyyy-MM-dd")))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
           .ForMember(dest => dest.PedidoCompleto, opt => opt.MapFrom(src => JsonSerializer.Serialize(src, AppConstants.JsonSerializerOptions)));

        CreateMap<Pedido, PedidoCriado>()
            .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.DataPedido, opt => opt.MapFrom(src => src.DataPedido.ToString("yyyy-MM-dd")))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        CreateMap<PedidoCriado, CriarPedidoResponse>();
    }
}
