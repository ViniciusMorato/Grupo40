using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IProductRepository
{
    Produto InsertUpdateProduct(Produto product);
    Produto? GetProductById(int id);
    List<Produto> GetProducts();
    void DeleteProduct(Produto product);
}