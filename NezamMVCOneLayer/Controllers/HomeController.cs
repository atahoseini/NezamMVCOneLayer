using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
using NezamMVCOneLayer.Services.Members;
using NezamMVCOneLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NezamMVCOneLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        public string ReturnUrl { get; set; }

        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Parvandeh, string Password, [FromServices] IIsUserAuthenticatedService isUserAuthenticatedService )
        {
            var requestMember = isUserAuthenticatedService.Execute(Parvandeh, Password);
            if (requestMember is null)
            {
                return View(nameof(Login));
            }

            //Save LogedInUser Into Session;
            return View("Index");
        }


        public IActionResult Authorization([FromServices] IGetCheckupUsersService getCheckupUsersService )
        {
            var logedInUserId = 3;

            var checkupUsers = getCheckupUsersService.Execute(logedInUserId);


            return View(checkupUsers);
        }
    }
}
