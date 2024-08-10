using System.ComponentModel.DataAnnotations;
using Core.Enums;


namespace Adapter.Api.DTO;

public class UpdateProductDto
{
    [Required(ErrorMessage = "Campo Descricao é obrigatório")]
    [MaxLength(100, ErrorMessage = "O campo descrição precisa ser menor que 100 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Campo Preco é obrigatório")]
    [Range(0.0, Double.MaxValue, ErrorMessage = "O campo preco precisa ser maior que zero")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Campo Estoque é obrigatório")]
    [Range(1, Int32.MaxValue, ErrorMessage = "O campo estoque precisa ser maior que zero")]
    public int Estoque { get; set; }

    [Required(ErrorMessage = "Campo categoria é obrigatório")]
    [EnumDataType(typeof(Category), ErrorMessage = "Categoria inválida.")]
    public Category Categoria { get; set; }
}