using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public Pedido Pedido { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }
        [Required]
        public decimal PrecoUnitario {  get; set; }

        public string? Observacao { get; set; }
    }
}
