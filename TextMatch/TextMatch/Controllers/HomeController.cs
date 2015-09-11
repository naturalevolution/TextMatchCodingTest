using System.Web.Mvc;
using TextMatch.Common.Messages;
using TextMatch.Factories;
using TextMatch.Models;

namespace TextMatch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = FrontResource.Home_Title;
            return View("Index");
        }

        public ActionResult Match()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Match(StringMatchModel model)
        {
            ViewBag.Title = FrontResource.Home_Title;
            if (ModelState.IsValid)
            {
                model.Positions = Factory.String.Match(model.Text, model.SubText);
            }
            else
            {
                model.ErrorMessage = ErrorResource.ModelState_NotValid;
            }
            return View("Index", model);
        }
    }
}