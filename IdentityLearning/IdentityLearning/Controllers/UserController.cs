using IdentityLearning.Models;
using IdentityLearning.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;
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

		public async Task<IActionResult> EditUser(string UserId) 
		{
			var User =await _UserManger.FindByIdAsync(UserId);
			var ApplicationUser = new ApplicationUser
			{
				Id = UserId,
				Email = User.Email,
				FirtName = User.FirtName,
				PhoneNumber = User.PhoneNumber,
				SecoundName = User.SecoundName,
				UserName = User.UserName,
				Picture=User.Picture
			};
			return View(ApplicationUser);

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditUser(ApplicationUser user) 
		{
			var _User = await _UserManger.FindByIdAsync(user.Id);
            if (!ModelState.IsValid)
				return View(user);
			var email =await _UserManger.FindByEmailAsync(user.Email);
			if (email!=null && email.Id != user.Id)
			{
				ModelState.AddModelError("Email", "This email is for another user");
				return View(user);
			}
			
				_User.FirtName = user.FirtName;
				_User.SecoundName = user.SecoundName;
				_User.UserName = user.UserName;
				_User.Email = user.Email;
			_User.PhoneNumber = user.PhoneNumber;
			if (Request.Form.Files.Count > 0)
			{
				var file = Request.Form.Files.FirstOrDefault();
				//check file size and extension
				using (var datestream = new MemoryStream())
				{
					await file.CopyToAsync(datestream);
					_User.Picture = datestream.ToArray();
				}
			}

                var result=await _UserManger.UpdateAsync(_User);
              

            return RedirectToAction(nameof(Index));

		}
	}
}
