using Microsoft.AspNetCore.Mvc;
using Online_store.Data;
using System.Web;

using Microsoft.AspNetCore.Mvc;
using Online_store.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace Online_store.Controllers
{
    public class LoginController : Controller
    {
        private readonly OnlineStoreContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginController(OnlineStoreContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager; 
            _signInManager = signInManager; 
        }

        public ViewResult Login()
        {
            var users = _context.Users.ToList();
            return View(users);
        }


    }
  }
