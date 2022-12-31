using IdentityLearning.Models;
using IdentityLearning.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLearning.Controllers
{
	[Authorize(Roles ="Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<ApplicationUser> _UserManger;
		private readonly RoleManager<IdentityRole> _RoleManger;

		public UserController(UserManager<ApplicationUser> Usermanger,RoleManager<IdentityRole> RoleManger)
		{
			_UserManger = Usermanger;
			_RoleManger = RoleManger;
		}
		public async Task<IActionResult> Index()
		{
		
			var users = await _UserManger.Users.Select(user=>new UserViewModel
			{
				Email=user.Email,
				FirstName=user.FirtName,
				LastName=user.SecoundName,
				UserName=user.UserName,
				id=user.Id,
				Roles=_UserManger.GetRolesAsync(user).Result
			}).ToListAsync();
			return View(users);
		}




		public async Task<IActionResult> MangeRoles(string UserId)
		{
			var user = await _UserManger.FindByIdAsync(UserId);
			if (user == null)
			{
				return NotFound();
			}
			var Roles = await _RoleManger.Roles.ToListAsync();
			var viewModel = new UserRoleViewModel
			{
				UserName = user.UserName,
				Id = user.Id,
				Roles = Roles.Select(role => new RolesViewModel
				{
					RoleId = role.Id,
					RoleName = role.Name,
					CheckingRole = _UserManger.IsInRoleAsync(user, role.Name).Result
				}).ToList()
			};
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MangeRoles(UserRoleViewModel model)
		{
			var user = await _UserManger.FindByIdAsync(model.Id);
			if (user == null)
			{
				return NotFound();
			}
			var UserRoles = await _UserManger.GetRolesAsync(user);
			foreach (var role in model.Roles)
			{
				if (UserRoles.Any(r => r == role.RoleName) && !role.CheckingRole)
				{
					await _UserManger.RemoveFromRoleAsync(user, role.RoleName);
				}
				if (!UserRoles.Any(r => r == role.RoleName) && role.CheckingRole)
				{
					await _UserManger.AddToRoleAsync(user, role.RoleName);
				}
			}
			return RedirectToAction(nameof(Index));

		}
	}
}
