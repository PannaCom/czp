using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using comzipato.Models;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity;
using System.Net;
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
        public ActionResult Admin(int? pg, string search)
        {
            if (Configs.getCookie("admin") == null || Configs.getCookie("admin") == "")
            {
                return RedirectToAction("Login", "Admin"); //RedirectToAction("Login", "Admin");
            }
            int pageSize = 25;
            if (pg == null) pg = 1;
            int pageNumber = (pg ?? 1);
            ViewBag.pg = pg;
            var data = db.partners.Select(x => x);
            if (data == null)
            {
                return View(data);
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                data = data.Where(x => x.phone.ToLower().Contains(search) || x.full_name.Contains(search) || x.email.Contains(search));
                ViewBag.search = search;
            }

            data = data.OrderByDescending(x => x.id);
            return View(data.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Reg()
        {
            return View();
        }
        public ActionResult AddNew()
        {
            if (Configs.getCookie("admin") == null || Configs.getCookie("admin") == "")
            {
                return RedirectToAction("Login", "Admin");
            }
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
        public ActionResult List(int? pg,string address,long? product_id, double? lon, double? lat, int? d)
        {
            int pageSize = 25;
            if (pg == null) pg = 1;
            int pageNumber = (pg ?? 1);
            ViewBag.pg = pg;
            if (d == null) d = 100000;
            if (lon == null) lon = 105.8194541;
            if (lat == null) lat = 21.0227431;
            string query = "select * from (SELECT TOP 1000 [id],[email],[full_name],[phone],[address],[lon],[lat],ACOS(SIN(PI()*" + lat + "/180.0)*SIN(PI()*lat/180.0)+COS(PI()*" + lat + "/180.0)*COS(PI()*lat/180.0)*COS(PI()*lon/180.0-PI()*" + lon + "/180.0))*6371 As D  FROM [comzipato].[dbo].[partner]) as A where 1=1 ";
            if (lon != null)
            {
                query += " and D<=" + d;
            }
            var data = db.Database.SqlQuery<spt>(query).OrderBy(x => x.D).ToList();
            if (data == null)
            {
                return View(data);
            }
            //if (!string.IsNullOrWhiteSpace(search))
            //{
            //    search = search.Trim();
            //    data = data.Where(x => x.product_name.ToLower().Contains(search));
            //    ViewBag.search = search;
            //}

            //data=data.OrderBy(x => x.D);
            ViewBag.lon = lon;
            ViewBag.lat = lat;
            ViewBag.address = address;
            ViewBag.d = d;
            ViewBag.pname = "";
            ViewBag.pphoto = "";
            ViewBag.product_id = 0;
            if (product_id != null && product_id != 0)
            {
                var p = db.products.Find((long)product_id);
                ViewBag.pname = p.product_name;
                ViewBag.pphoto = p.product_photo;
                ViewBag.product_id=product_id;
            }
            return View(data.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return RedirectToRoute("Admin");
            }
            partner _model = db.partners.Find(id);
            if (_model == null)
            {
                return View(_model);
            }

            return View(_model);
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(partner partner)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Vui lòng kiểm tra lại các trường.";
                return RedirectToAction("Edit", new { id = partner.id });
            }
            if (ModelState.IsValid)
            {
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(partner);
        }
        public ActionResult Delete(int? id)
        {
            if (Configs.getCookie("admin") == null || Configs.getCookie("admin") == "")
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null || id == 0)
            {
                return RedirectToRoute("Admin");
            }
            partner _model = db.partners.Find(id);
            if (_model == null)
            {
                return View(_model);
            }

            return View(_model);
        }
        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            partner pt = db.partners.Find(id);
            db.partners.Remove(pt);
            db.SaveChanges();
            return RedirectToAction("Admin");
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
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNew(Partner model)
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

                return RedirectToAction("Admin");
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