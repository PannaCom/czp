using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using comzipato.Models;
using PagedList;
namespace comzipato.Controllers
{
    public class ProductsController : Controller
    {
        private comzipatoEntities db = new comzipatoEntities();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        // GET: Cats
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult List(int? pg, string search)
        {
            int pageSize = 25;
            if (pg == null) pg = 1;
            int pageNumber = (pg ?? 1);
            ViewBag.pg = pg;
            var data = db.products.Select(x => x);
            if (data == null)
            {
                return View(data);
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                data = data.Where(x => x.product_name.ToLower().Contains(search));
                ViewBag.search = search;
            }

            data = data.OrderBy(x => x.updated_date);
            return View(data.ToList().ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult _lstOptionCatPartial()
        {
            List<LstCat> data = db.cats.Select(x => new LstCat()
            {
                CatId = x.cat_id,
                CatName = x.cat_name,
                ParentCatId = x.cat_parent_id,
                CatPos = x.cat_pos,
                CatURL = x.cat_url
            }).OrderBy(x => x.CatPos).ToList();

            var presidents = data.Where(x => x.ParentCatId == null || x.ParentCatId ==-1).FirstOrDefault();
            SetChildrenCat(presidents, data);
            return PartialView("_lstOptionCatPartial", presidents);
        }
        private void SetChildrenCat(LstCat model, List<LstCat> danhmuc)
        {
            var childs = danhmuc.Where(x => x.ParentCatId == model.CatId).ToList();
            if (childs.Count > 0)
            {
                foreach (var child in childs)
                {
                    SetChildrenCat(child, danhmuc);
                    model.LstCats.Add(child);
                }
            }
        }
        public ActionResult LoadPhotoProduct(long? id)
        {
            var model = db.products.Find(id).product_img.ToList();
            return PartialView("_LoadPhotoProduct", model);
        }
    }
}