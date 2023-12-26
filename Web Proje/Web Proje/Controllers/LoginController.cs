using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web_Proje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private PetDeryasıEntities db = new PetDeryasıEntities();

        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(MÜŞTERİ müsteri)
        {
            var müsteriInDb = db.MÜŞTERİ.FirstOrDefault(x => x.müşteriAdı == müsteri.müşteriAdı && x.parola == müsteri.parola);
            if (müsteriInDb != null)
            {
                FormsAuthentication.SetAuthCookie(müsteri.müşteriAdı, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya parola! Tekrar Deneyin.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
    
      
}