using Core.Entities;

namespace Core.Interfaces.Services;

public interface IProductService
{
    Produto AddNewProduct(Produto product);
    Produto? GetProductById(int id);
    List<Produto> GetProducts();
    Produto UpdateProduct(Produto product);
    void DeleteProduct(int id);
}