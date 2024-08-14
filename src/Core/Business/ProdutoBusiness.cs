using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Business;

public class ProdutoBusiness(IProductRepository productRepository, IOrderItensRepository orderItensRepository) : IProductService
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

    public Produto UpdateProduct(Produto product)
    {
        product.Validade();
        Produto productExist = GetProductById(product.Id);
        if (productExist == null)
        {
            throw new ArgumentException("Produto não encontrado");
        }
        productExist.Descricao = product.Descricao;
        productExist.Preco = product.Preco;
        productExist.Estoque = product.Estoque;
        productExist.Categoria = product.Categoria;
        return productRepository.InsertUpdateProduct(productExist);
    }

    public void DeleteProduct(int id)
    {
        Produto product = productRepository.GetProductById(id);
        if (product == null)
            throw new ArgumentException("Produto não encontrado");

        if (orderItensRepository.CheckProducIsUsedByOrder(id))
            throw new ArgumentException("Esse produto não pode ser excluido pois é usado em um pedido");

        productRepository.DeleteProduct(product);
    }
}