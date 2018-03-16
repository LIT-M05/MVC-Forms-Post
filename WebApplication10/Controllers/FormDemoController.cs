using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class FormDemoController : Controller
    {
        public ActionResult Index()
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeoleConStr);
            int count = mgr.GetPeopleCount();
            PeopleViewModel vm = new PeopleViewModel
            {
                PeopleCount = count
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddPerson(string firstName, string lastName, int age)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeoleConStr);
            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
            mgr.AddPerson(person);
            return Redirect("/formdemo/index");
        }
    }
}

//create a page that displays a table full of people (or anything else you want)
//On top of the table, there should be a link, that says "Add Person". When that 
//link is clicked, the user should be taken to a page that has a form to add a person

//On that form, when the add button is clicked, the person should get added to the 
//database, and the user should get redirected back to the home page e.g. the page
//with the table of people