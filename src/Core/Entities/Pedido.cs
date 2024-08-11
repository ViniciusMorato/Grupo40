using Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Pedido")]
    public sealed class Pedido
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public int Usuario { get; set; }

        [Required]
        public int UsuarioEndereco {  get; set; }

        [Required]
        public decimal ValorTotal { get; set; }

        [Required]
        public decimal ValorEntrega { get; set; }

        [Required]
        public int QuantidadeProdutos { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        [MaxLength(30)]
        public EnumStatusPedido StatusPedido { get; set; }

        [Required]
        [MaxLength(30)]
        public EnumFormaPagamento FormaPagamento { get; set; }

        public List<PedidoItem>? PedidoItens { get; set; } = new List<PedidoItem>();

        public void Validade()
        {
            if (!Enum.IsDefined(typeof(EnumFormaPagamento), this.FormaPagamento))
            {
                throw new ArgumentException("Forma Pagamento não pode ser vazio");
            }
            if (!Enum.IsDefined(typeof(EnumStatusPedido), this.StatusPedido))
            {
                throw new ArgumentException("Status Pedido Pagamento não pode ser vazio");
            }
            if (this.ValorTotal <= 0)
            {
                throw new ArgumentException("O valor total não pode ser menor ou igual a zero");
            }
            if (this.ValorEntrega < 0)
            {
                throw new ArgumentException("O valor total não pode ser menor que zero");
            }
            if(this.QuantidadeProdutos <= 0)
            {
                throw new ArgumentException("A quantidade de produtos não pode ser menor ou igual a zero");
            }
        }
    }
}
