using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public sealed class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<ItemPedido> itemPedidos { get; set; }

    }
}
