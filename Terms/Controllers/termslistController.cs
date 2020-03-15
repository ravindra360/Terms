using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terms.Models;

namespace Terms.Controllers
{
    public class termslistController : Controller
    {
        public ActionResult BulkData()
        {
            // This is only for show by default one row for insert data to the database
            List<Term>   ci = new List<Term> { new Term { MOT_ID = 0, Abbreviations  = "", Definition = "" } };
            return View(ci);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]C:\Users\rkumbar\Desktop\mazur\back up\Terms\19_2_19_two\Terms\Terms\Controllers\TermsController.cs
        public ActionResult BulkData(List<Term> ci)
        {
            if (ModelState.IsValid)
            {
                using (termsEntities dc = new termsEntities())
                {
                    foreach (var i in ci)
                    {
                        dc.Terms.Add(i);
                    }
                    dc.SaveChanges();
                    ViewBag.Message = "Data successfully saved!";
                    ModelState.Clear();
                    ci = new List<Term> { new Term { MOT_ID = 0, Abbreviations = "", Definition = "" } };
                }
            }
            return View(ci);
        }

    }
}
