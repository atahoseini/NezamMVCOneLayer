using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
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

                    if (objFromDb.isAuthorized == true)
                        return View("Index", objFromDb);
                    else
                    {
                         return RedirectToAction("Authorization", objFromDb);
                    }
                }
                else
                    TempData["msg"] = "Admin id or Password is wrong.!";
                return View(nameof(Login));
            }
            return View(nameof(Login));
        }


        public IActionResult Authorization(Member objFromDb)
        {
            List<MemberAuth> model = MemberDetail(objFromDb);
            return View(model);
        }


        public List<MemberAuth> MemberDetail(Member membre)
        {

            #region LIST

            List<string> lstFatherName = new List<string>();
            List<string> lstMotherName = new List<string>();
            List<string> lstSHSH = new List<string>();
            List<MemberAuth> MemberAuths = new List<MemberAuth>();

            List<int> fi = RandomList(1, 20, 8);

            lstFatherName.Insert(0, membre.FatherFirstName);
            for (int i = 1; i < 8; i++)
            {

                var tmpName = SD.ListOFFirstName[fi[i]];
                if (tmpName != membre.FatherFirstName)
                {
                    lstFatherName.Insert(i, tmpName);
                    if (lstFatherName.Count >= 4)
                        break;
                }
            }
            lstFatherName = Randomize(lstFatherName);



            lstMotherName.Insert(0, membre.MotherLastName);
            for (int i = 1; i < 8; i++)
            {
                var tmpName = SD.ListOFFamily[fi[i]];
                if (tmpName != membre.MotherLastName)
                {
                    lstMotherName.Insert(i, tmpName);
                    if (lstMotherName.Count >= 4)
                        break;
                }
            }
            lstMotherName = Randomize(lstMotherName);



              lstSHSH.Insert(0, membre.Shsh);
            for (int i = 1; i < 8; i++)
            {
                var tmpName = SD.ListOFSHSH[fi[i]].ToString();
                if (tmpName.ToString() != membre.Shsh.ToString())
                {
                    lstSHSH.Insert(i, tmpName.ToString());
                    if (lstSHSH.Count >= 4)
                        break;
                }
            }
            lstSHSH = Randomize(lstSHSH);

            #endregion


            for (int i = 0; i < lstFatherName.Count; i++)
            {
                MemberAuth memberAuth = new MemberAuth();
                memberAuth.id = i + 1;
                memberAuth.FatherName = lstFatherName[i];
                if (lstFatherName[i] == membre.FatherFirstName)
                    memberAuth.IsFather = true;
                else
                    memberAuth.IsFather = false;
                memberAuth.MotherName = lstMotherName[i];
                if (lstMotherName[i] == membre.MotherLastName)
                    memberAuth.IsMother = true;
                else
                    memberAuth.IsMother = false;

                memberAuth.ShSH = lstSHSH[i];
                 if (lstSHSH[i] == membre.Shsh)
                    memberAuth.IsSHSH = true;
                else
                    memberAuth.IsSHSH = false;
                MemberAuths.Add(memberAuth);
            }

            return MemberAuths;
        }


        private List<int> RandomList(int min,int max,int count)
        {
            List<int> listNumbers = new List<int>();
            Random random = new Random();
            listNumbers.AddRange(Enumerable.Range(min, max)
                                .OrderBy(i => random.Next())
                                .Take(count));
            return listNumbers;
        }

        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> randomizedList = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count); //pick a random item from the master list
                randomizedList.Add(list[index]); //place it at the end of the randomized list
                list.RemoveAt(index);
            }
            return randomizedList;
        }
    }
}
