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
