using Newtonsoft;
using System.ComponentModel.DataAnnotations;

namespace Adapter.Api.DTO
{
    public class AddPessoaEnderecoDto
    {
        [Required(ErrorMessage = "")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "")]
        public string Numero { get; set; }

        public string Complemento { get; set; }
    }

    public class ReturnPessoaEnderecoDto
    {
        [Required(ErrorMessage = "")]
        public int Id { get; set; }

        [Required(ErrorMessage = "")]
        public int Cliente { get; set; }

        [Required(ErrorMessage = "")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "")]
        public string Numero { get; set; }

        public string Complemento { get; set; }
    }
}
