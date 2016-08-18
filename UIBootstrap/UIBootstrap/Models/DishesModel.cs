using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIBootstrap.Models
{
    public class DishesModel
    {
        public List<string> Dishes_List { get; set; }

        // Pagination
        public int? Page { get; set; }
        public int TotalDishesCount { get; set; }
        public IPagedList<string> DishesPageList { get; set; }
    }
}