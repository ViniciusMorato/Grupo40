using Core.Entities;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Adapter.Api.DTO
{
    public class AddPedidoDTO
    {
        public AddPedidoDTO()
        {           
            PedidoItens = new List<AddPedidoItemDto>();
        }

        public int Usuario { get; set; }

        public int UsuarioEndereco {  get; set; }

        public decimal ValorEntrega {  get; set; }

        public EnumFormaPagamento FormaPagamento {  get; set; }

        public List<AddPedidoItemDto> PedidoItens {  get; set; } 
    }

    public class AddPedidoItemDto
    {
        public AddPedidoItemDto()
        {
        }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public string Observacao { get; set;}
    }

    public class ReturnPedidoDto
    {
        public ReturnPedidoDto() { }

        public int Id { get; set; }

        public int Usuario { get; set; }

        public int UsuarioEndereco { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorEntrega { get; set; }

        public int QuantidadeProdutos { get; set; }

        public DateTime DataPedido { get; set; }

        public EnumStatusPedido StatusPedido { get; set; }

        public EnumFormaPagamento FormaPagamento { get; set; }

        public List<ReturnPedidoItemDto> PedidoItens { get; set; }
    }

    public class ReturnPedidoItemDto
    {
        public ReturnPedidoItemDto() { }

        public int Id { get; set; }

        public int PedidoId { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public string? Observacao { get; set; }
    }

    public class ClienteCartaoCreditoDto
    {
        public int PessoaId { get; set; }

        public EnumTipoCartao TipoCartao { get; set; }

        public string NomeNoCartao { get; set; }

        public string Numero { get; set; }

        public string Vencimento { get; set; }

        public string CVV { get; set; }
    }
}
