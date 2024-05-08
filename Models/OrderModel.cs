#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;
public interface IOrderRepository
{
    OrderModel GetOrderById(int orderId);
    void SaveOrder(OrderModel order);
    void DeleteOrder(int orderId);
}

public partial class OrderModel
{
    [Key]
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; }
    public OrderModel GetOrderById(int orderId)
    {
        // TODO: Implement logic to fetch order by ID
        throw new NotImplementedException();
    }

    public void SaveOrder(OrderModel order)
    {
        // TODO: Implement logic to save/update order
        throw new NotImplementedException();
    }

    public void DeleteOrder(int orderId)
    {
        // TODO: Implement logic to delete order by ID
        throw new NotImplementedException();
    }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();

    public virtual UserModel User { get; set; }
}