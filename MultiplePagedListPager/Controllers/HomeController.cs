using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiplePagedListPager.Models;
using PagedList;

namespace MultiplePagedListPager.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksEntities _context;

        public HomeController()
        {
            _context = new AdventureWorksEntities();
        }
        
        // GET: Home
        public ActionResult Index(PageModel pageModel)
        {
            var productsBelowReorder = (from prod in _context.Products
                                        join prodInv in _context.ProductInventories
                                        on prod.ProductID equals prodInv.ProductID
                                        where prodInv.Quantity < prod.ReorderPoint
                                        select new ProductViewModel()
                                        {
                                            ProductID = prod.ProductID,
                                            ProductName = prod.Name,
                                            ProductNumber = prod.ProductNumber,
                                            ListPrice = prod.ListPrice,
                                            LocationID = prodInv.LocationID,
                                            Quantity = prodInv.Quantity,
                                            ReorderPoint = prod.ReorderPoint
                                        }).ToList();

            var productsAboveReorder = (from prod in _context.Products
                                        join prodInv in _context.ProductInventories
                                        on prod.ProductID equals prodInv.ProductID
                                        where prodInv.Quantity >= prod.ReorderPoint
                                        select new ProductViewModel()
                                        {
                                            ProductID = prod.ProductID,
                                            ProductName = prod.Name,
                                            ProductNumber = prod.ProductNumber,
                                            ListPrice = prod.ListPrice,
                                            LocationID = prodInv.LocationID,
                                            Quantity = prodInv.Quantity,
                                            ReorderPoint = prod.ReorderPoint
                                        }).ToList();

            var model = new ProductPageModel(pageModel)
            {
                ProductsBelowReorder = productsBelowReorder.ToPagedList(pageModel.BelowReorderPage, pageModel.Size),
                ProductsAboveReorder = productsAboveReorder.ToPagedList(pageModel.AboveReorderPage, pageModel.Size)
            };

            return View(model);
        }
    }
}