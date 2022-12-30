using IdentityLearning.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentityLearning.Controllers
{
	[Authorize(Roles ="Admin")]
	public class IdentityRoles : Controller
	{
		private readonly RoleManager<IdentityRole> _roleManager;

		public IdentityRoles(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
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
	}
}
