using System.ComponentModel.DataAnnotations;

namespace Adapter.Api.DTO;

public class ProductDto
{
    public int Id { get; set; }

    public string Descricao { get; set; }

    public decimal Preco { get; set; }

    public int Estoque { get; set; }
}