using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FakeCartao
    {
        public FakeCartao() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        public EnumTipoCartao TipoCartao { get; private set; }

        [Required]
        [MaxLength(500)]
        public string NomeNoCartao { get; private set; }

        [Required]
        [MaxLength(500)]
        public string Numero { get; private set; }

        [Required]
        [MaxLength(5)]
        public string Vencimento { get; private set; }

        [Required]
        [MaxLength(200)]
        public string CVV { get; private set; }
    }
}
