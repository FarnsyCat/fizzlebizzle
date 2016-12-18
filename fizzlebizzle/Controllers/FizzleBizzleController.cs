using fizzlebizzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace fizzlebizzle.Controllers
{
    public class FizzleBizzleController : Controller
    {
        // GET: FizzleBizzle
        public ActionResult Introduction()
        {
            return View();
        }

        public ActionResult Game()
        {
            return View(new FizzleBizzleModel());
        }

        [HttpPost]
        public ActionResult Game(FizzleBizzleModel model)
        {
            model.isValid = false;
            if(model.Start > model.End)
            {
                ModelState.AddModelError("StartGreaterThanEnd", "Start needs to be less than End");
            }
            if(model.isFizzBuzzBazz)
            {
                if (model.Bazz < 1)
                {
                    ModelState.AddModelError("BazzLessThan1", "Bazz needs to be bigger than 1");
                }
                if (model.Predicate.ToString() == "0")
                {
                    ModelState.AddModelError("PredicateNotSet", "Please Select a Predicate");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.isValid = true;
                return View(model);
            }
           


           
        }
    }
}