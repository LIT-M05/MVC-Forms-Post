using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult SearchProducts()
        {
            return View();
        }

        public ActionResult SearchResults(int? minStock, int? maxStock)
        {
            if (minStock == null)
            {
                minStock = 1;
            }
            if (maxStock == null)
            {
                maxStock = 100;
            }
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Product> products = mgr.SearchByStock(minStock, maxStock);
            SearchResultsViewModel vm = new SearchResultsViewModel
            {
                Products = products,
                MinStock = minStock,
                MaxStock = maxStock
            };
            return View(vm);
        }

        public ActionResult SearchOnePage(int? minStock, int? maxStock)
        {
            if (minStock == null && maxStock == null)
            {
                return View(new SearchResultsViewModel());
            }

            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Product> products = mgr.SearchByStock(minStock, maxStock);
            SearchResultsViewModel vm = new SearchResultsViewModel
            {
                Products = products,
                MinStock = minStock,
                MaxStock = maxStock
            };
            return View(vm);


        }
    }
}