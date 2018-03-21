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

        public ActionResult Edit(int id)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeoleConStr);
            Person person = mgr.GetById(id);
            if (person == null)
            {
                return Redirect("/people/index");
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeoleConStr);
            mgr.UpdatePerson(person);
            return Redirect("/people/index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeoleConStr);
            mgr.Delete(id);
            return Redirect("/people/index");
        }
    }
}