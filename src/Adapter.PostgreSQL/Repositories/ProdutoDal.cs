using Adapter.PostgreSQL.Context;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Adapter.PostgreSQL.Repositories;

public class ProdutoDal : IProductRepository
{
    private readonly PostgreSqlContext _context;

    public ProdutoDal(PostgreSqlContext context)
    {
        _context = context;
    }

    public Produto InsertProduct(Produto product)
    {
        _context.Produtos.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Produto? GetProductById(int id)
    {
        return _context.Produtos.FirstOrDefault(product => product.Id == id);
    }

    public IEnumerable<Produto> GetProducts()
    {
        return _context.Produtos;
    }

    public Produto UpdateProduct(Produto product)
    {
        _context.SaveChanges();
        return product;
    }

    public void DeleteProduct(Produto product)
    {
        _context.Produtos.Remove(product);
    }
}