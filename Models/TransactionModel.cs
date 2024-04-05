#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public partial class TransactionModel
{
    [Key]
    public int TransactionId { get; set; }

    public int OrderId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string PaymentMethod { get; set; }

    public decimal Amount { get; set; }

    public virtual OrderModel Order { get; set; }
}