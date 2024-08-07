using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Model
{
    public class UsuarioModel
    {
        private const string CpfPattern = @"[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}";

        [Key] [Required] public int Id { get; set; }

        [Required(ErrorMessage = "Campo usuário é obrigatório")]
        [RegularExpression(CpfPattern, ErrorMessage = "Campo precisa ser um CPF válido")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [MinLength(8, ErrorMessage = "Campo senha precisa conter no mínimo 8 caracteres")]
        public string Senha { get; set; }

        [Required]
        [EnumDataType(typeof(AccessControl))]
        public AccessControl Papel { get; set; }
    }
}