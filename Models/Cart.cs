using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_store.Models
{
    public interface ICartRepository
    {
        Cart GetCart();
        void AddItem(int productId, int quantity);
        void RemoveItem(int productId);
        void ClearCart();
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart : ICartRepository
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

    public void AddItem(int productId, int quantity)
    {
        var existingItem = Items.FirstOrDefault(item => item.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
        }
    }
}
