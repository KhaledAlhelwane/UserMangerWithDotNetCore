using IdentityLearning.Models;
using IdentityLearning.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLearning.Controllers
{
	[Authorize(Roles ="Admin")]
	public class IdentityRoles : Controller
	{
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityRoles(RoleManager<IdentityRole> roleManager,
			UserManager<ApplicationUser> userManager)
		{
			_roleManager = roleManager;
            _userManager = userManager;
        }
		public async Task<IActionResult> Index()
		{
			var ListOfRoles = await _roleManager.Roles.ToListAsync();
			return View(ListOfRoles);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddnigRoles(RolesFormViewModel Model)
		{
			if (!ModelState.IsValid)
			{
				return View("Index", await _roleManager.Roles.ToListAsync());
			}
			var roleExist = await _roleManager.RoleExistsAsync(Model.Name);
			if(roleExist)
			{
				ModelState.AddModelError("Name", "Role is exist");
				return View("Index", await _roleManager.Roles.ToListAsync());
			}
			await _roleManager.CreateAsync(new IdentityRole( Model.Name));
			return View("index", await _roleManager.Roles.ToListAsync());
		} 
		public async Task<IActionResult> AddUser()
		{
			var ListaOfRoles = await _roleManager.Roles.ToListAsync();

            var NewUser = new UserPropritesViewModel
			{
				ListaOfRoles = ListaOfRoles
            };
		
			return View(NewUser);

		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddUser(UserPropritesViewModel modle)
		{
			if (!ModelState.IsValid) 
			{
				ViewBag.message = "you have to fix and rich all requirments";
			}
			
            var user = new ApplicationUser {UserName=modle.Email, Email = modle.Email, FirtName = modle.FirstName, SecoundName = modle.SecoundName };
            var result = await _userManager.CreateAsync(user, modle.Password);
			if (result.Errors.Count()>0)
			{
                ViewBag.message = "Duplicate Usser Email";
                var ListaOfRoles = await _roleManager.Roles.ToListAsync();

                var NewUser = new UserPropritesViewModel
                {
                    ListaOfRoles = ListaOfRoles
                };

                return View(NewUser);
            }
			if (result.Succeeded)
			{
				ViewBag.sucess = "User created a new account with password.";
               
                await _userManager.AddToRoleAsync(user, modle.TheRole);
				var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			}
			return RedirectToAction(nameof(Index));
		}

    }
}
