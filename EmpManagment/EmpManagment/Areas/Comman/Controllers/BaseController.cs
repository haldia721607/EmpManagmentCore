using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmpManagmentBOL.Tables;
using EmpManagmentIBLL.ICommanRepositry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmpManagment.Areas.Comman.Controllers
{
    [AllowAnonymous]
    [Area("Comman")]
    public class BaseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public readonly IAccountRepository _accountRepository;

        protected UserManager<ApplicationUser> userManager;
        protected SignInManager<ApplicationUser> signInManager;
        protected ILogger<AccountController> logger;
        protected IAccountRepository accountRepository;
        public BaseController()
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _accountRepository = accountRepository;
        }   
    }
}
