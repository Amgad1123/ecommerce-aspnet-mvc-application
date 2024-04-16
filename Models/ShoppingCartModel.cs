using Online_store.Data;
using Microsoft.AspNetCore.Http;
using System;
namespace Online_store.Models
{
    public class ShoppingCartModel
    {
        private readonly OnlineStoreContext _context;
        private ShoppingCartModel(OnlineStoreContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public static ShoppingCartModel GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var cont = services.GetService<OnlineStoreContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCartModel(cont) { ShoppingCartId = cartId };
        }

        //Get shooping cart items
        /*public List<OrderItem> GetShoppingCartItems()
        {
            return GetShoppingCartItems ?? 
                (ShoppingCartItems = 
                _context.ShoppingCartItems.Where(c=> c.ShoppingCartId == ShoppingCartId).Include(s=>).ToList());
        }*/
        // Add items to cart
        /*public void AddToCart(,int Amount)
        {

        }*/
    }

}
