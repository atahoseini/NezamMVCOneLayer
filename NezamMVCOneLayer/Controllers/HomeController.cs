using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
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

        public HomeController(IUnitOfWork unitOfWork,ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(string Parvandeh, string Password)
        {
            if (ModelState.IsValid)
            {
                var objFromDb = _unitOfWork.Member.GetFirstOrDefault(x => x.Parvandeh == Parvandeh && x.Password == Password, includeProperties: "Field,City");
                if (objFromDb != null)
                {
                    ViewData["Name"] = "Hello " + objFromDb.FirstName + " " + objFromDb.LastName;
                    ViewData["Field"] = objFromDb.FieldId;
                    ViewData["FieldName"] = objFromDb.Field.FieldName;
                    ViewData["CityId"] = objFromDb.CityId;
                    ViewData["CityName"] = objFromDb.City.CityName;
                    return View("Index", objFromDb);
                }
                else
                    TempData["msg"] = "Admin id or Password is wrong.!";
                return View(nameof(Login));
            }
            return View(nameof(Login));
        }


    }
}
