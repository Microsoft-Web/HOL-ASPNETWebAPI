using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManager.Parts;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private IContactRepository _contactRepository;

        public HomeController(IContactRepository contactRepo)
        {
            _contactRepository = contactRepo;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
