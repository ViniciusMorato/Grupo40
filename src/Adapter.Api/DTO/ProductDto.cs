using Core.Enums;
using System.ComponentModel.DataAnnotations;


namespace Adapter.Api.DTO;

public class ProductDto : AddProductDto
{
    public int Id { get; set; }
}

public class AddProductDto
{

    [Required(ErrorMessage = "Campo Descricao é obrigatório")]
    [MaxLength(100, ErrorMessage = "O campo Descricao precisa ser menor que 500 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Campo Preco é obrigatório")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Campo Estoque é obrigatório")]
    public int Estoque { get; set; }

    [Required(ErrorMessage = "Campo Categoria é obrigatório")]
    public EnumCategoria Categoria { get; set; }

}