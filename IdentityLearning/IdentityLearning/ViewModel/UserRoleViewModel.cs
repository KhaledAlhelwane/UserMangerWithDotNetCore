using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace IdentityLearning.ViewModel
{
	public class UserRoleViewModel
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public List<RolesViewModel> Roles { get; set; }
	}
}
