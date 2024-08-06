using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio.Model
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<ItemPedidoModel> itemPedidos { get; set; }

    }
}
