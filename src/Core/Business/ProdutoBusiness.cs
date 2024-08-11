using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Business;

public class ProdutoBusiness(IProductRepository productRepository) : IProductService
{
    public Produto AddNewProduct(Produto product)
    {
        product.Validade();
        var productExist = GetProductById(product.Id);
        if (productExist != null)
        {
            return productExist;
        }

        Produto newProduct = productRepository.InsertUpdateProduct(product);
        return newProduct;
    }

    public Produto? GetProductById(int id)
    {
        return productRepository.GetProductById(id);
    }

    public List<Produto> GetProducts()
    {
        return productRepository.GetProducts();
    }

    public Produto? UpdateProduct(Produto product)
    {
        product.Validade();
        var productExist = GetProductById(product.Id);
        if (productExist != null)
        {
            return productRepository.InsertUpdateProduct(product);
        }

        return null;
    }

    public void DeleteProduct(Produto product)
    {
        productRepository.DeleteProduct(product);
    }
}