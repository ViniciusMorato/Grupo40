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

            //Entity -> DTO
            CreateMap<UsuarioEndereco, ReturnPessoaEnderecoDto>();
            CreateMap<Pedido, ReturnPedidoDto>();
            CreateMap<PedidoItem, ReturnPedidoItemDto>();
            CreateMap<Produto, ReturnProductDto>();
        }
    }
}
