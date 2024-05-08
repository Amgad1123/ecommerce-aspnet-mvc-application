#nullable disable
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public partial class ProductModel
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

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

    public class ProductsDBContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
    }



}