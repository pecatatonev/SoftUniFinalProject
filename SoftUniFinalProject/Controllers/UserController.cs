using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Admin.Identity;
using SoftUniFinalProject.Core.Models.Admin;
using SoftUniFinalProject.Core.Models.Identity;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using System.Runtime.CompilerServices;
using static SoftUniFinalProject.Core.Constants.RoleConstants;

namespace SoftUniFinalProject.Controllers
{
    public class UserController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserService userService;

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<ApplicationRole> _roleManager,
            IUserService _userService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
        }
        //CHECK REDIRRECTION
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (await userManager.IsInRoleAsync(user, AdministratorRole))
                    {
                        return RedirectToAction("Users", "Home", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddRole()
        {
            var model = new RoleAddViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddRole(RoleAddViewModel model)
        {
            if (await roleManager.RoleExistsAsync(model.RoleName) == false)
            {
                await roleManager.CreateAsync(userService.RoleCreate(model.RoleName));
            }
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddUserToRole()
        {
            var model = new UserToRoleAddViewModel()
            {
                Users = await userManager.Users.Select(u => new UsersViewModel()
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                })
                .ToListAsync(),
                Roles = await roleManager.Roles.Select(x =>new RoleListViewModel()
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                }).ToListAsync(),
            };

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddUserToRole(UserToRoleAddViewModel model) 
        {
            var role =await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == model.RoleId);

            if (await roleManager.RoleExistsAsync(role.Name)) 
            {
                var user = await userManager.FindByIdAsync(model.UserId);

                if (user != null)
                {
                    if (await userManager.IsInRoleAsync(user, role.Name) == false)
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
