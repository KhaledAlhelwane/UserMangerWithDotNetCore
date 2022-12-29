using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using IdentityLearning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityLearning.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string firstname { get; set; }
            public  string secoudname { get; set; }
            public string phonenumber{ get; set; }
            public byte[] picture { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
            firstname=user.FirtName
            ,secoudname=user.SecoundName
            ,phonenumber=user.PhoneNumber
            ,picture=user.Picture
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            
            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
               if (Input.firstname != user.FirtName)
            {
                user.FirtName = Input.firstname;
                var setfirstname = await _userManager.UpdateAsync(user);
                if (!setfirstname.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set first name.";
                    return RedirectToPage();
                }
            }
            if (Input.secoudname != user.SecoundName)
            {
                user.SecoundName = Input.secoudname;
                var setsecoundname = await _userManager.UpdateAsync(user);
                if (!setsecoundname.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set secoundname";
                    return RedirectToPage();
                }
            }
            if (Input.phonenumber != user.PhoneNumber) 
            {
                user.PhoneNumber = Input.phonenumber;
                var result =await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                { 
                    StatusMessage= "Unexpected error when trying to set phon number";
                }
            }
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                //check file size and extension
                using (var datestream = new MemoryStream())
                {
                    await file.CopyToAsync(datestream);
                    user.Picture = datestream.ToArray();
                }
              await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
