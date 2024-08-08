using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Entities
{
    public sealed class Usuario
    {
        private const string CpfPattern = @"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$";

        [Key] [Required] public int Id { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Nome não pode ultrapassar 100 caracteres")]
        public string Nome { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Sobrenome não pode ultrapassar 100 caracteres")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Campo usuário é obrigatório")]
        [RegularExpression(CpfPattern, ErrorMessage = "Campo precisa ser um CPF válido: 123.123.123-12")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [MinLength(8, ErrorMessage = "Campo senha precisa conter no mínimo 8 caracteres")]
        public string Senha { get; set; }

        [Required]
        [EnumDataType(typeof(AccessControl))]
        public AccessControl Papel { get; set; }
    }
}