public class CartItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class Cart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public void AddItem(int productId, int quantity)
    {
        // Check if the product is already in the cart
        var existingItem = Items.FirstOrDefault(item => item.ProductId == productId);

        if (existingItem != null)
        {
            // If the product is already in the cart, update the quantity
            existingItem.Quantity += quantity;
        }
        else
        {
            // If the product is not in the cart, add it as a new item
            Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
        }
    }
}
