using Microsoft.AspNetCore.Mvc;
using Online_store.Data;

namespace Online_store.Controllers
{
    public class UserController : Controller
    {
        private readonly OnlineStoreContext _context;

        public UserController(OnlineStoreContext context)
        {
            _context = context;
        }
        public ViewResult Users()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}
