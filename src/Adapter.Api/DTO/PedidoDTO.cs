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

        [Required(ErrorMessage = "Campo Usuario é obrigatório")]
        public int Usuario { get; set; }

        [Required(ErrorMessage = "Campo UsuarioEndereco é obrigatório")]
        public int UsuarioEndereco {  get; set; }

        [Required(ErrorMessage = "Campo ValorEntrega é obrigatório")]
        public decimal ValorEntrega {  get; set; }

        [Required(ErrorMessage = "Campo FormaPagamento é obrigatório")]
        public EnumFormaPagamento FormaPagamento {  get; set; }

        [Required(ErrorMessage = "Campo PedidoItens é obrigatório")]
        public List<AddPedidoItemDto> PedidoItens {  get; set; } 
    }

    public class AddPedidoItemDto
    {
        public AddPedidoItemDto()
        {
        }

        [Required(ErrorMessage = "Campo ProdutoId é obrigatório")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo Quantidade é obrigatório")]
        public int Quantidade { get; set; }

        [MaxLength(100, ErrorMessage = "O campo Observacao precisa ser menor que 100 caracteres")]
        public string? Observacao { get; set;}
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
        [Required(ErrorMessage = "Campo PessoaId é obrigatório")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Campo TipoCartao é obrigatório")]
        public EnumTipoCartao TipoCartao { get; set; }

        [Required(ErrorMessage = "Campo Observacao é obrigatório")]
        [MaxLength(500, ErrorMessage = "O campo Observacao precisa ser menor que 500 caracteres")]
        public string NomeNoCartao { get; set; }

        [Required(ErrorMessage = "Campo Numero é obrigatório")]
        [MaxLength(16, ErrorMessage = "O campo Numero precisa ser menor que 16 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo Vencimento é obrigatório")]
        [MaxLength(5, ErrorMessage = "O campo Vencimento precisa ser menor que 5 caracteres")]
        public string Vencimento { get; set; }

        [Required(ErrorMessage = "Campo CVV é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo CVV precisa ser menor que 3 caracteres")]
        public string CVV { get; set; }
    }

    public class ReturnClienteCartaoCreditoDto : ClienteCartaoCreditoDto
    {
        public int Id { get; set; }
    }

    public class ReturnPedidoPix
    {
        public int Id { get; private set; }

        public int PedidoId { get; set; }

        public string CodigoPix { get; set; }
    }
}
