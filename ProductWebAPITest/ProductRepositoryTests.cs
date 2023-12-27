using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductAPI.Models;
using ProductAPI.Repos;
using Xunit;

namespace ProductWebAPITest
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void GetProductById_ProductFound_ReturnsProduct()
        {
            // Arrange
            var repository = new ProductRepo();
            int productId = 1;

            // Act
            var product = repository.GetProductById(productId);

            // Assert
            Assert.NotNull(product);
            Assert.Equal(productId, product.ProductId);
        }

        [Fact]
        public void AddProduct_ValidProduct_ReturnsAddedProduct()
        {
            // Arrange
            var repository = new ProductRepo();
            var newProduct = new Products
            {
                ProductName = "New Laptop",
                ProductBrand = "Dell",
                ProductQuantity = 5,
                ProductPrice = 1200.0m
            };

            // Act
            var addedProduct = repository.AddProduct(newProduct);

            // Assert
            Assert.NotNull(addedProduct);
            Assert.Equal(newProduct.ProductName, addedProduct.ProductName);
            Assert.Equal(newProduct.ProductBrand, addedProduct.ProductBrand);
            Assert.Equal(newProduct.ProductQuantity, addedProduct.ProductQuantity);
            Assert.Equal(newProduct.ProductPrice, addedProduct.ProductPrice);
        }

        [Fact]
        public void UpdateProduct_ValidIdAndProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            var repository = new ProductRepo();
            int productId = 1;
            var updatedProduct = new Products
            {
                ProductName = "Updated Laptop",
                ProductBrand = "Dell",
                ProductQuantity = 8,
                ProductPrice = 1500.0m
            };

            // Act
            var result = repository.UpdateProduct(productId, updatedProduct);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.ProductId);
            Assert.Equal(updatedProduct.ProductName, result.ProductName);
            Assert.Equal(updatedProduct.ProductBrand, result.ProductBrand);
            Assert.Equal(updatedProduct.ProductQuantity, result.ProductQuantity);
            Assert.Equal(updatedProduct.ProductPrice, result.ProductPrice);
        }

        [Fact]
        public void DeleteProduct_ValidId_ReturnsDeletedProductName()
        {
            // Arrange
            var repository = new ProductRepo();
            int productId = 1;

            // Act
            var deletedProductName = repository.DeleteProduct(productId);

            // Assert
            Assert.NotNull(deletedProductName);
            Assert.Equal("Laptop", deletedProductName); // Assuming the sample data contains a product with the name "Laptop"
        }

    }
}
