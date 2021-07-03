using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alar.BLL.Interfaces;
using alar.DAL.Classes.UserClasses;
using alar.Presentation.Models.SecurityModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace alar.Presentation.Controllers
{

    public class SecurityController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public SecurityController(IUnitOfWork _uow, IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CustomerLogin()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UserLogin()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CustomerRegister(CustomerUserRegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                var cusromerUser = mapper.Map<UserClass>(model);
                cusromerUser.UserTypes = DAL.Enums.UserTypes.Admin;
                await uow.SecurityRepository.AddUser(cusromerUser);
                await uow.SaveChangesAsync();
                return RedirectToAction("CustomerFirstCreate", new { ID = cusromerUser.ID });
            }
            catch (Exception)
            {
                ModelState.AddModelError("All", "Bir Sorun Oluştu");
                return View();
            }
            
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyUserName(string userName)
        {//Kullanıcı Adı Kotrol
            if (uow.SecurityRepository.VerifyUserName(userName))
            {
                return Json($"{userName} bu kullanıcı adı kullanılıyor");
            }

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {//Kullanıcı Email Control
            if (uow.SecurityRepository.VerifyEmail(email))
            {
                return Json($"Bu Email kullanılıyor");
            }

            return Json(true);
        }
        public async Task<IActionResult> CustomerFirstCreate(int ID)
        {

            return View();
        }

    }
}
