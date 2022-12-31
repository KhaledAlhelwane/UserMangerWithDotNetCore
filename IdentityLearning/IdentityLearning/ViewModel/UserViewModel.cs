﻿using System.Collections.Generic;

namespace IdentityLearning.ViewModel
{
	public class UserViewModel
	{
		public string id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public IList<string> Roles { get; set; }
	}
}
