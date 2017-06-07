using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using comzipato.Models;
namespace comzipato.Controllers
{
    public class adminController : Controller
    {
        private comzipatoEntities db = new comzipatoEntities();
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Configs.RemoveCookie("admin");
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user model)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Vui lòng kiểm tra lại các trường.");
                return View(model);
            }
            long? _id = 0;
            try
            {
                string passHash = Configs.GetMd5Hash(model.pass);
                var login = db.users.Where(x => x.username == model.username && x.pass == passHash).FirstOrDefault();
                if (login == null)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                    return View(model);
                }
                _id = login.id;
                Configs.setCookie("admin", _id.ToString());

            }
            catch (Exception ex)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index");
        }
    }
}