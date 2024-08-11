using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Dominio
    {
        public Dominio() { }

        [Required]
        [StringLength(30)]
        public string Chave {  get; private set; }

        [Required]
        [StringLength(50)]
        public string Descricao {  get; private set; }

        [Required]
        public int DominioId {  get; private set; }
    }
}
