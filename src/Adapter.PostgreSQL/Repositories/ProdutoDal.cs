using Adapter.PostgreSQL.Context;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adapter.PostgreSQL.Repositories;

public class ProdutoDal : IProductRepository
{
    private readonly PostgreSqlContext _context;

    public ProdutoDal(PostgreSqlContext context)
    {
        _context = context;
    }

    public Produto InsertUpdateProduct(Produto product)
    {
        if(product.Id == 0)
        {
            _context.Produtos.Add(product);
        }
        _context.SaveChanges();
        return product;
    }

    public Produto? GetProductById(int id)
    {
        return _context.Produtos.FirstOrDefault(product => product.Id == id);
    }

    public List<Produto> GetProducts()
    {
        return _context.Produtos.ToList();
    }

    public void DeleteProduct(Produto product)
    {
        _context.Produtos.Remove(product);
        _context.SaveChanges();
    }
}