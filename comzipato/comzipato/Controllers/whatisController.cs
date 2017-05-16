using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace comzipato.Controllers
{
    public class whatisController : Controller
    {
        // GET: whatis
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult overview()
        {
            return View();
        }
        public ActionResult security()
        {
            return View();
        }
        public ActionResult energy()
        {
            return View();
        }
        public ActionResult comfort()
        {
            return View();
        }
        public ActionResult health()
        {
            return View();
        }
    }
}