using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeoleConStr);
            return View(mgr.GetAll());
        }

        public ActionResult ShowAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeoleConStr);
            mgr.AddPerson(person);
            return Redirect("/people/index");
        }

        [HttpPost]
        public void HiddenDemo(string junk, string foobar)
        {
            Response.Write($"<h1>Foobar: {foobar}</h1><h1>Junk: {junk}</h1>");
        }
    }
}