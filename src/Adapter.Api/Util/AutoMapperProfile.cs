using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;

namespace Adapter.Api.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //DTO -> Entity
            CreateMap<AddPessoaEnderecoDto, UsuarioEndereco>();
            CreateMap<AddPedidoDTO, Pedido>();
            CreateMap<AddPedidoItemDto, PedidoItem>();
            CreateMap<ClienteCartaoCreditoDto, CartaoCredito>();
            CreateMap<ProductDto, Produto>();

            //Entity -> DTO
            CreateMap<UsuarioEndereco, ReturnPessoaEnderecoDto>();
            CreateMap<Pedido, ReturnPedidoDto>();
            CreateMap<PedidoItem, ReturnPedidoItemDto>();
            CreateMap<Produto, ProductDto>();
            CreateMap<Produto, UpdateProductDto>();
            CreateMap<CartaoCredito, ReturnClienteCartaoCreditoDto>();
            CreateMap<PedidoPix, ReturnPedidoPix>();
        }
    }
}
