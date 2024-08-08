using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Entities
{
    public sealed class Usuario
    {
        [Key] public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string SobreNome { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public AccessControl Papel { get; set; }
    }
}