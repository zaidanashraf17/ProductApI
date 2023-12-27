using ProductAPI.Models;

namespace ProductAPI.Repos
{
    public class ProductRepo: IProductRepo
    {
        
        private readonly List<Products> products;

        public ProductRepo()
        {
            // Initialize with some sample data
            products = new List<Products>
        {
            new Products { ProductId = 1, ProductName = "Laptop", ProductBrand = "HP", ProductQuantity = 10, ProductPrice = 1000.0m },
            new Products { ProductId = 2, ProductName = "Phone", ProductBrand = "Samsung", ProductQuantity = 20, ProductPrice = 500.0m }
        };
        }

        public List<Products> GetAllProducts()
        {
            return products;
        }

        public Products GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Products> GetProductsByName(string productName)
        {
            return products.Where(p => p.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Products AddProduct(Products product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
            return product;
        }

        public Products UpdateProduct(int productId, Products updatedProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.ProductBrand = updatedProduct.ProductBrand;
                existingProduct.ProductQuantity = updatedProduct.ProductQuantity;
                existingProduct.ProductPrice = updatedProduct.ProductPrice;
                return existingProduct;
            }
            return null;
        }

        public string DeleteProduct(int productId)
        {
            var productToRemove = products.FirstOrDefault(p => p.ProductId == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                return productToRemove.ProductName;
            }
            return null;
        }
    }
}
