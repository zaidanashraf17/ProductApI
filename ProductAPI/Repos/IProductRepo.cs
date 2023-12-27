using ProductAPI.Models;

namespace ProductAPI.Repos
{
    public interface IProductRepo
    {
        List<Products> GetAllProducts();
        Products GetProductById(int productId);
        List<Products> GetProductsByName(string productName);
        Products AddProduct(Products product);
        Products UpdateProduct(int productId, Products updatedProduct);
        string DeleteProduct(int productId);
    }
}
