using Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
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
        public StatusPedido StatusPedido { get; set; }

        [Required]
        [MaxLength(30)]
        public FormaPagamento FormaPagamento { get; set; }

        public void Validade()
        {
            if (!Enum.IsDefined(typeof(FormaPagamento), this.FormaPagamento))
            {
                throw new ArgumentException("Forma Pagamento não pode ser vazio");
            }
            if (!Enum.IsDefined(typeof(StatusPedido), this.StatusPedido))
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
