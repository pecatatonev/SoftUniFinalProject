using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Admin.Identity;
using SoftUniFinalProject.Core.Models.Admin;
using SoftUniFinalProject.Core.Services.Admin.UserService;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;
using static SoftUniFinalProject.Core.Constants.RoleConstants;

namespace SoftUniFinalProject.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        public HomeController(UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationRole> _roleManager,
            IUserService _userService)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            userService = _userService;
        }   
       
        public async Task<IActionResult> Users()
        {
            var users = await userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            var model = new RoleAddViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddViewModel model)
        {
            if (await roleManager.RoleExistsAsync(model.RoleName) == false)
            {
                return StatusCode(500);
            }

            await roleManager.CreateAsync(userService.RoleCreate(model.RoleName));

            return RedirectToAction(nameof(Users));
        }

        [HttpGet]
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
                Roles = await roleManager.Roles.Select(x => new RoleListViewModel()
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                }).ToListAsync(),
            };

            return View(model);
        }

        public async Task<IActionResult> AddUserToRole(UserToRoleAddViewModel model)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == model.RoleId);

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

            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return StatusCode(404);
               
            }

            await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Users));
        }
    }
}
