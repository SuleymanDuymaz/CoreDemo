using Identity.Models;
using Identity.Quickstart.Account;
using IdentityModel;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Is4RoleDemo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace Identity.IdentityServer.Register
{
    [Authorize(Roles ="admin")]
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
      
        public RegisterController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
    
        }



        [HttpGet]
     
        public async Task<IActionResult> Register()
        {
            List<string> roles = new()
            {
                Config.Admin,
               
                Config.Customer
            };
            ViewData["roles_message"] = roles;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ResigterInputModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    //Active=true

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(model.RoleName).GetAwaiter().GetResult())
                    {
                        var userRole = new IdentityRole
                        {
                            Name = model.RoleName,
                            NormalizedName = model.RoleName,

                        };
                        await _roleManager.CreateAsync(userRole);
                    }
                    await _userManager.AddToRoleAsync(user, model.RoleName);


                    await _userManager.AddClaimsAsync(user, new Claim[] {

                        new Claim(JwtClaimTypes.Email,model.Email),
                        new Claim(JwtClaimTypes.Role,model.RoleName)
                    });
                    return RedirectToAction("Login", "Account");




                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    List<string> roles = new()
        {
            Config.Admin,
         
            Config.Customer
        };
                    ViewData["roles_message"] = roles;


                    return View(model);
                }

            }
            else
            {
                List<string> roles = new()
        {
            Config.Admin,
           
            Config.Customer
        };
                ViewData["roles_message"] = roles;

            
                return View(model);
            }

            return View();
        }
    }
}
