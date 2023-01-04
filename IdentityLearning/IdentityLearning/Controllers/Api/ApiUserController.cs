using IdentityLearning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IdentityLearning.Controllers.Api
{
	[Route("api/[Controller]")]
	[ApiController]
	[Authorize(Roles ="Admin")]

	public class ApiUserController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _UserManger;

		public ApiUserController(UserManager<ApplicationUser> UserManger)
		{
			_UserManger = UserManger;
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(string UserId)
		{

			var user =await _UserManger.FindByIdAsync(UserId);
			if (user == null)
				return NotFound();

			var result = await _UserManger.DeleteAsync(user);
			if (!result.Succeeded)
				throw new Exception( );
			return Ok();
		}

	}
}
