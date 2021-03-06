﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using SportsFinder.Data.Models;
using SportsFinder.Data;
using System.Collections.Generic;
using System.Linq;

namespace SportsFinder.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _DB;
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender, ApplicationDbContext DB)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _DB = DB;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public List<Sport> Sports { get; set; }
        public List<Gender> Genders { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Display Name")]
            public string DisplayName { get; set; }
            [Display(Name = "Location")]
            public string Location { get; set; }
            [Display(Name = "Birthday")]
            public DateTime Birthday { get; set; }
           

            public int? GenderId { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var displayName = user.DisplayName;
            var location = user.Location;
            
            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                DisplayName = displayName,
                Location = location,
                GenderId=user.GenderId,
                Birthday = user.BirthDate,
              
            };
            Genders = _DB.Genders.ToList();

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            
            if(user.DisplayName != Input.DisplayName)
            {
                var dnuser = await _userManager.GetUserAsync(User); //TODO: Contemplate whethether to use this or not(?)
                dnuser.DisplayName = Input.DisplayName; 
                var setDsiplayName = await _userManager.UpdateAsync(dnuser);
                if (!setDsiplayName.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(dnuser);
                    throw new InvalidOperationException($"Unexpected error occurred setting Display name for user with ID '{userId}'.");
                }
            }

            if (user.Location != Input.Location)
            {
                var dnuser = await _userManager.GetUserAsync(User); //TODO: Contemplate whethether to use this or not(?)
                dnuser.Location = Input.Location;
                var setDsiplayName = await _userManager.UpdateAsync(dnuser);
                if (!setDsiplayName.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(dnuser);
                    throw new InvalidOperationException($"Unexpected error occurred setting Location for user with ID '{userId}'.");
                }
            }
            if (user.GenderId != Input.GenderId)
            {
                var dnuser = await _userManager.GetUserAsync(User); //TODO: Contemplate whethether to use this or not(?)
                dnuser.GenderId = Input.GenderId;
                var setDsiplayName = await _userManager.UpdateAsync(dnuser);
                if (!setDsiplayName.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(dnuser);
                    throw new InvalidOperationException($"Unexpected error occurred setting gender for user with ID '{userId}'.");
                }
            }
            if (user.BirthDate != Input.Birthday)
            {
                var dnuser = await _userManager.GetUserAsync(User); //TODO: Contemplate whethether to use this or not(?)
                dnuser.BirthDate = Input.Birthday;
                var setDsiplayName = await _userManager.UpdateAsync(dnuser);
                if (!setDsiplayName.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(dnuser);
                    throw new InvalidOperationException($"Unexpected error occurred setting birthday for user with ID '{userId}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}