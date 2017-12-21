using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace MultiplePagedListPager.Models
{
    public class PageModel
    {
        public int BelowReorderPage { get; set; }
        public int AboveReorderPage { get; set; }
        public int Size { get; set; }

        public PageModel()
        {
            BelowReorderPage = 1;
            AboveReorderPage = 1;
            Size = 10;
        }
    }

    public class ProductPageModel
    {
        public PageModel PageModel { get; set; }
        public ProductPageModel(PageModel pageModel)
        {
            ProductsBelowReorder = new PagedList<ProductViewModel>(new List<ProductViewModel>(), 1, pageModel.Size);
            ProductsAboveReorder = new PagedList<ProductViewModel>(new List<ProductViewModel>(), 1, pageModel.Size);
            PageModel = pageModel;
        }

        public IPagedList<ProductViewModel> ProductsBelowReorder { get; set; }
        public IPagedList<ProductViewModel> ProductsAboveReorder { get; set; }
    }
}