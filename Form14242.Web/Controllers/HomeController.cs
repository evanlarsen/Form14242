using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Form14242.Web.ViewModels;
using Form14242.Web.Core;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;

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
            
            vm.Artifacts = GetArtifacts(Request);
            using (Repository store = new Repository())
            {
                store.Form14242.Add(vm);
                try
                {
                    store.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                    throw dbEx;
                }
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
                form = store.Form14242.Include("Preparers").Include("Promoters").Include("Artifacts").Where(p => p.ID == id).FirstOrDefault();
            }
            if (form == null)
            {
                throw new HttpException(404, string.Format("No Form found with the id of {0}", id));
            }
            return View(form);
        }

        public ActionResult DownloadFile(int id)
        {
            using (Repository store = new Repository())
            {
                Artifact file = store.Artifacts.FirstOrDefault(f => f.ID == id);

                if (file == null) { throw new HttpException(404, "HTTP/1.1 404 Not Found"); }

                return File(file.FileContents, file.ContentType);

            }
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

        private List<Artifact> GetArtifacts(HttpRequestBase request)
        {
            List<Artifact> artifacts = new List<Artifact>();
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];
                artifacts.Add(CreateArtifact(file.FileName, file));
            }
            return artifacts;
        }

        private Artifact CreateArtifact(string fileName, HttpPostedFileBase file)
        {
            var inputStream = file.InputStream;

            Artifact fileEntity = new Artifact();
            fileEntity.Name = Path.GetFileName(fileName);
            fileEntity.ContentType = file.ContentType;

            byte[] fileContents = new byte[file.ContentLength];
            inputStream.Read(fileContents, 0, file.ContentLength);
            fileEntity.FileContents = fileContents;

            return fileEntity;
        }
    }
}
