using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models
{
    public interface IOrderItemRepository
    {
        OrderItem GetOrderItemById(int orderItemId);
        void SaveOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int orderItemId);
    }

    public partial class OrderItem : IOrderItemRepository
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual OrderModel Order { get; set; }

        public virtual ProductModel Product { get; set; }

        public OrderItem GetOrderItemById(int orderItemId)
        {
            // TODO: Implement logic to fetch order item by ID
            throw new NotImplementedException();
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            // TODO: Implement logic to save/update order item
            throw new NotImplementedException();
        }

        public void DeleteOrderItem(int orderItemId)
        {
            // TODO: Implement logic to delete order item by ID
            throw new NotImplementedException();
        }
    }
}
