using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class SearchResultsViewModel
    {
        public IEnumerable<Product> Products {get; set; }
        public int? MinStock { get; set; }
        public int? MaxStock { get; set; }
    }
}