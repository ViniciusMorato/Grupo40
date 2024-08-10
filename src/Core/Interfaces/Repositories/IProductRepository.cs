using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IProductRepository
{
    Produto InsertProduct(Produto product);
    Produto? GetProductById(int id);
    IEnumerable<Produto> GetProducts();
    Produto UpdateProduct(Produto product);
    void DeleteProduct(Produto product);
}