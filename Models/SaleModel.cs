#nullable disable
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Online_store.Models;

public partial class SaleModel
{
    public SaleModel()
    {
    }
    [Key]
    public int SalesID { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int ProductID { get; set; }

    public  decimal Price { get; set; }

    public virtual string Name {  get; set; }

    public decimal SalesPercentage { get; set; }

    public virtual ProductModel Product { get; set; }

   
}