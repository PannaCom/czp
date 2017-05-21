using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using comzipato.Models;
using System.Threading.Tasks;
namespace comzipato.Controllers
{
    public class PartnerController : Controller
    {
        private comzipatoEntities db = new comzipatoEntities();
        // GET: Partner
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(long? product_id)
        {
            return View();
        }
        public ActionResult Reg()
        {
            return View();
        }
        public ActionResult Log(string title)
        {
            ViewBag.title2 = title;
            return View();
        }
        public class logincs
        {
            public string email { get; set; }
            public string pass { get; set; }
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Login(logincs lg)
        {
            try
            {
                var any = db.partners.Any(o=>o.email==lg.email && o.pass==lg.pass);
                if (!any)
                {
                    return RedirectToAction("Log", new { title = "Sai Email hoặc Mật khẩu" });
                }
                else return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Log", new { title = "Sai Email hoặc Mật khẩu" });
            }
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Partner model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Errored"] = "Vui lòng kiểm tra lại các trường.";
                return View(model);
            }

            try
            {
                int id = 0;
                partner pn = new partner();
                pn.address = model.address;
                pn.email = model.email;
                pn.full_name = model.full_name;
                pn.lat = model.lat;
                pn.lon = model.lon;
                pn.pass = model.pass;
                pn.phone = model.phone;
                db.partners.Add(pn);
                
                await db.SaveChangesAsync();
                
                return RedirectToAction("Log", new { title = "Đăng Ký Thành Công, Chúng Tôi Sẽ Liên Hệ Sớm Nhất." });
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm mới");
                //configs.SaveTolog(ex.ToString());
                return View(model);
            }

        }
    }
}