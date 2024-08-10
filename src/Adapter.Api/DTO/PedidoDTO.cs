using Core.Enums;

namespace Adapter.Api.DTO
{
    public class AddPedidoDTO
    {
        public AddPedidoDTO()
        {
            Itens = new List<AddPedidoItemDto>();
        }

        public int Usuario { get; set; }
        public int UsuarioEndereco {  get; set; }
        public decimal ValorEntrega {  get; set; }
        public FormaPagamento FormaPagamento {  get; set; }
        public string Observacao { get; set; }
        public List<AddPedidoItemDto> Itens {  get; set; } 
    }

    public class AddPedidoItemDto
    {
        public AddPedidoItemDto()
        {
        }

        public int Id { get; set; }

        public int Quantidade { get; set; }


    }
}
