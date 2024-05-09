#nullable disable
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public interface IProductRepository
{
    ProductModel GetProductById(int productId);
    void SaveProduct(ProductModel product);
    void DeleteProduct(int productId);
    string GetNameNoSpace();
}

public partial class ProductModel : IProductRepository
{
    public ProductModel()
    {
        //Sales = new HashSet<SaleModel>();
    }
    [Key]
    public int ProductId { get; set; }
    public int ProductID { get; internal set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int QuantityInStock { get; set; }
    public ProductModel GetProductById(int productId)
    {
        // TODO: Implement this
        return new ProductModel { ProductId = productId, Name = "Dummy Product", Description = "Dummy Description", Price = 0, QuantityInStock = 0 };
    }

    public void SaveProduct(ProductModel product)
    {
        // TODO: Implement this
        Console.WriteLine($"Saving product: {product.Name}, {product.Description}, {product.Price}, {product.QuantityInStock}");
    }

    public void DeleteProduct(int productId)
    {
        // TODO: Implement this
        Console.WriteLine($"Deleting product with ID: {productId}");
    }

    public string GetNameNoSpace()
    {
        return this.Name.Replace(' ', '_');
    }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

    public class ProductsDBContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
    }



}