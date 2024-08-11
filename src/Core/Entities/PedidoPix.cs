using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PedidoPix
    {
        public PedidoPix() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int PedidoId {  get; set; }
        
        public Pedido Pedido { get; set; }

        [Required]
        [MaxLength(1000)]
        public string CodigoPix {  get; set; }
    }
}
