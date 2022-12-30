using System.ComponentModel.DataAnnotations;

namespace IdentityLearning.ViewModel
{
	public class RolesFormViewModel
	{
		[Required,StringLength(20)]
		public string Name { get; set; }
	}
}
