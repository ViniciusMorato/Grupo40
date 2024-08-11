using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UsuarioEndereco
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }
    }
}
