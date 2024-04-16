using Microsoft.AspNetCore.Mvc;
using Online_store.Data;
using System.Web;

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

        public IActionResult Login(string returnUrl)
        {
            return View(new UserModel()
            {
                ReturnUrl = returnUrl
            }) ;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            if (!ModelState.IsValid)
                return View(userModel);
            var user = await _userManager.FindByNameAsync(userModel.Username);
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userModel.PasswordHash, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(userModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(userModel.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Username/password not found");
            return View(userModel); 
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            if(ModelState.IsValid) {
                var user1 = new IdentityUser() { UserName = userModel.Username };
                var result = await _userManager.CreateAsync(user1, userModel.PasswordHash); 
                if(result.Succeeded) {
                    return RedirectToAction("Index", "Home");
                } 
            }
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
  }
