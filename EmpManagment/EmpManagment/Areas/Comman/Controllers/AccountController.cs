using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EmpManagment.Models;
using EmpManagmentBOL.Tables;
using EmpManagmentBOL.ViewModels.CommanArea.ViewModels;
using EmpManagmentBOL.ViewModels.CommanAreaViewModels;
using EmpManagmentIBLL.ICommanRepositry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmpManagment.Areas.Comman.ControllersRegister
{
    [AllowAnonymous]
    [Area("Comman")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IAccountRepository accountRepository, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins =
                (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
                    {
                        ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                        return View(model);
                    }
                    // The last boolean parameter lockoutOnFailure indicates if the account
                    // should be locked on failed logon attempt. On every failed logon
                    // attempt AccessFailedCount column value in AspNetUsers table is
                    // incremented by 1. When the AccessFailedCount reaches the configured
                    // MaxFailedAccessAttempts which in our case is 5, the account will be
                    // locked and LockoutEnd column is populated. After the account is
                    // lockedout, even if we provide the correct username and password,
                    // PasswordSignInAsync() method returns Lockedout result and the login
                    // will not be allowed for the duration the account is locked.
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,true);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Dashboard", "Dashboard", new { Area = "User" });
                    }
                    // If account is lockedout send the use to AccountLocked view
                    if (result.IsLockedOut)
                    {
                        return View("AccountLocked");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email not exist");
                    return View(model);
                }

            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            //Check any remote error from google
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }
            //Get External login info
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return View("Login", loginViewModel);
            }

            // Get the email claim from external login provider (Google, Facebook etc)
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            ApplicationUser user = null;
            if (email != null)
            {
                // Find the user
                user = await _userManager.FindByEmailAsync(email);
                // If email is not confirmed, display login view with validation error
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View("Login", loginViewModel);
                }
            }
            //Signin with external registerd login provider
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                if (email != null)
                {
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        //Create new in AspNetUsers Table
                        var result = await _userManager.CreateAsync(user);
                        if (result.Succeeded)
                        {
                            //Insert external loging provider user in AspNetUserLogins Table
                            await _userManager.AddLoginAsync(user, info);
                            //Get user details by email id
                            var getUserByEmail = await _userManager.FindByEmailAsync(info.Principal.FindFirstValue(ClaimTypes.Email));
                            //Generate Email Confirmation Token
                            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var confirmationLInk = Url.Action("ConfirmEmail", "Account", new { area = "Comman", userId = getUserByEmail.Id, token = token }, Request.Scheme);
                            string Ref = "NewAccountConfirmation";
                            int isSendSuccess = CommanFunction.SendConfirmationLink(confirmationLInk, getUserByEmail.UserName, getUserByEmail.Email, Ref);
                            if (isSendSuccess == 1)
                            {
                                if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                                {
                                    return RedirectToAction("Dashboard", "Dashboard", new { Area = "User" });
                                }
                                ViewBag.Success = "Registration successful";
                                ViewBag.Message = "Before you can Login, please confirm your email, by clicking on the confirmation link we have emailed you";
                                return View("RegistrationSuccessful");
                            }
                        }
                    }
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return LocalRedirect(returnUrl);
                }
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            var countryList = _accountRepository.CounteryList().ToList();
            if (countryList != null)
            {
                foreach (var country in countryList)
                {
                    registerViewModel.Countries.Add(new SelectListItem { Text = country.CountryName, Value = country.CountryId.ToString() });
                }
            }
            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    CountryId = model.countryId,
                    StateId = model.stateId,
                    CityId = model.cityId
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLInk = Url.Action("ConfirmEmail", "Account", new { area = "Comman", userId = user.Id, token = token }, Request.Scheme);
                    string Ref = "NewAccountConfirmation";
                    int isSendSuccess = CommanFunction.SendConfirmationLink(confirmationLInk, model.Name, model.Email, Ref);
                    if (isSendSuccess == 1)
                    {
                        if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                        {
                            return RedirectToAction("Dashboard", "Dashboard", new { Area = "User" });
                        }
                        ViewBag.Success = "Registration successful";
                        ViewBag.Message = "Before you can Login, please confirm your email, by clicking on the confirmation link we have emailed you";
                        return View("RegistrationSuccessful");
                    }
                }
                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                var countryList = _accountRepository.CounteryList().ToList();
                if (countryList != null)
                {
                    foreach (var country in countryList)
                    {
                        model.Countries.Add(new SelectListItem { Text = country.CountryName, Value = country.CountryId.ToString() });
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public JsonResult GetStatelist(int countryId)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            var states = _accountRepository.StateList(countryId);
            if (states != null)
            {
                foreach (var item in states)
                {
                    registerViewModel.States.Add(new SelectListItem
                    {
                        Text = item.StateName,
                        Value = Convert.ToString(item.StateId)
                    });
                }
                return Json(registerViewModel);
            }
            return Json(null);
        }
        [HttpGet]
        public JsonResult GetCitylist(int stateId)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            var cities = _accountRepository.CityList(stateId);
            if (cities != null)
            {
                foreach (var item in cities)
                {
                    registerViewModel.Cities.Add(new SelectListItem
                    {
                        Text = item.CityName,
                        Value = Convert.ToString(item.CityId)
                    });
                }
                return Json(registerViewModel);
            }
            return Json(null);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null && token == null)
            {
                return RedirectToAction("Register", "Account", new { area = "Comman" });
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }
            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { Area = "Comman" });
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);
                // If the user is found AND Email is confirmed
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    // Generate the reset password token
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { area = "Comman", email = model.Email, token = token }, Request.Scheme);
                    string Ref = "PasswordResetLink";
                    int isSendSuccess = CommanFunction.SendConfirmationLink(passwordResetLink, user.UserName, model.Email, Ref);
                    if (isSendSuccess == 1)
                    {
                        return View("ForgotPasswordConfirmation");
                    }
                    //Before you can Login, please reset your password, by clicking on the reset password link we have emailed you on your email-{model.Email} id.
                    // Log the password reset link
                    _logger.Log(LogLevel.Warning, passwordResetLink);

                    // Send the user to Forgot Password Confirmation view
                    return View("ForgotPasswordConfirmation");
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    // reset the user password
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        // Upon successful password reset and if the account is lockedout, set
                        // the account lockout end date to current UTC date time, so the user
                        // can login with the new password
                        if (await _userManager.IsLockedOutAsync(user))
                        {
                            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                        }
                        ViewBag.Success = "Reset password successful";
                        ViewBag.Message = $"You have successfully reset your passowd.Please loging with email-{model.Email} with your new password.";
                        return View("PasswordResetSuccessful");
                    }
                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                ViewBag.Success = "Reset password successful";
                ViewBag.Message = $"You have successfully reset your passowd.Please loging with registered email id with your new password.";
                return View("PasswordResetSuccessful");
            }
            // Display validation errors if model state is not valid
            return View(model);
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
