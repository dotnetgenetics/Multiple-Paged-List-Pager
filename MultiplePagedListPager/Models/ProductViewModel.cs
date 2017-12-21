using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiplePagedListPager.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public decimal ListPrice { get; set; }
        public int LocationID { get; set; }
        public int Quantity { get; set; }
        public int ReorderPoint { get; set; }
    }
}