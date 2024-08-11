using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CartaoCredito
    {
        public CartaoCredito() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int PessoaId { get; set; }

        public Usuario Pessoa { get; set; }

        [Required]
        public EnumTipoCartao TipoCartao { get; set; }

        [Required]
        [MaxLength(500)]
        public string NomeNoCartao { get; set; }

        [Required]
        [MaxLength(500)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(5)]
        public string Vencimento {  get; set; }

        [Required]
        [MaxLength(200)]
        public string CVV {  get; set; }

    }
}
