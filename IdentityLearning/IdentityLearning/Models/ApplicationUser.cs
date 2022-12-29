using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityLearning.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FirtName { get; set; }
        [Required]
        public string SecoundName { get; set; }
        public byte[] Picture { get; set; }

    }
}
