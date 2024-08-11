using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PedidoCartaoCredito
    {
        public PedidoCartaoCredito() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        [Required]
        public int CartaoCreditoId { get; set; }

        public CartaoCredito CartaoCredito { get; set;}
    }
}
