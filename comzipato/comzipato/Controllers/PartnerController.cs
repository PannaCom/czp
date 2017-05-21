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
        public ActionResult Reg()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Partner model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Errored"] = "Vui lòng kiểm tra lại các trường.";
                return RedirectToRoute("AdminAddProduct");
            }

            try
            {
                //long? idproduct = 0;
                //partner _new = new partner();
                //_new.cat_id = model.cat_id ?? null;
                //_new.product_name = model.product_name ?? null;
                //_new.product_content = model.product_content ?? null;
                //_new.product_photo = model.product_photo ?? null;
                //_new.product_photo2 = model.product_photo2 ?? null;
                //_new.product_price_public = model.product_price_public ?? null;
                ////_new.product_type = model.product_type ?? null;
                //_new.product_new_type = model.product_new_type ?? null;
                //_new.status = model.status;
                //_new.updated_date = DateTime.Now;
                //_new.product_des = model.product_des ?? null;
                //_new.lang = model.lang ?? null;
                //_new.product_feature = model.product_feature ?? null;
                //_new.product_technical = model.product_technical ?? null;
                //db.products.Add(_new);
                //db.SaveChanges();
                ////await db.SaveChangesAsync();
                //idproduct = _new.product_id;

                //TempData["Updated"] = "Thêm sản phẩm thành công";
                return RedirectToRoute("AdminEditProduct", new { id = 0 });
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