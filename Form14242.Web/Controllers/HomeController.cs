using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Form14242.Web.ViewModels;
using Form14242.Web.Core;

namespace Form14242.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form14242()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form14242(Form14242Model vm)
        {
            vm.ReportedDate = DateTime.Now;
            using (Repository store = new Repository())
            {
                store.Form14242.Add(vm);
                store.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewAll()
        {
            IEnumerable<Form14242Model> forms = new List<Form14242Model>();
            using (Repository store = new Repository())
            {
                forms = store.Form14242.Select(p => p).ToList();
            }
            return View(forms);
        }

        public ActionResult View(int id)
        {
            Form14242Model form = null;
            using (Repository store = new Repository())
            {
                form = store.Form14242.Include("Preparers").Include("Promoters").Where(p => p.ID == id).FirstOrDefault();
            }
            if (form == null)
            {
                throw new HttpException(404, string.Format("No Form found with the id of {0}", id));
            }
            return View(form);
        }

        [ChildActionOnly]
        public ActionResult _PromoterBrowserTemplate()
        {
            PromoterBrowserTemplateVM vm = new PromoterBrowserTemplateVM();
            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult _PreparerBrowserTemplate()
        {
            PreparerBrowserTemplateVM vm = new PreparerBrowserTemplateVM();
            return View(vm);
        }
    }
}
