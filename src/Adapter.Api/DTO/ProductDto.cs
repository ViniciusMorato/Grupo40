using Core.Enums;
using System.ComponentModel.DataAnnotations;


namespace Adapter.Api.DTO;

public class ProductDto
{
    public int Id { get; set; }

    public string Descricao { get; set; }

    public decimal Preco { get; set; }

    public int Estoque { get; set; }

    public string Categoria { get; set; }

    public ProductDto(int id, string descricao, decimal preco, int estoque, Category categoria)
    {
        Id = id;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
        Categoria = categoria.ToString();
    }
}

public class ReturnProductDto
{
    public int Id { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public Category Categoria { get; private set; }
}