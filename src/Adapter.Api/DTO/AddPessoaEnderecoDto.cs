using Newtonsoft;
using System.ComponentModel.DataAnnotations;

namespace Adapter.Api.DTO
{
    public class AddPessoaEnderecoDto
    {
        [Required(ErrorMessage = "Campo Cliente é obrigatório")]
        public int Cliente { get; set; }

        [Required(ErrorMessage = "Campo Rua é obrigatório")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Numero é obrigatório")]
        public string Numero { get; set; }

        public string Complemento { get; set; }
    }

    public class ReturnPessoaEnderecoDto : AddPessoaEnderecoDto
    {
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public int Id { get; set; }
    }
}
