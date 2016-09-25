using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIBootstrap.Models;

namespace UIBootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddPagination()
        {           
            return View();
        }

        public ActionResult GitTestGoogleMap()
        {
            return View();
        }

        public JsonResult dishesPagination(int? Page)
        {
            List<string> dishes = new List<string>();

            DishesModel dishes_model = new DishesModel();

            int pageSize = 10;
            int pageNumber = (Page ?? 1);

            List<Items_Matrix> itemsList = getItemsMatrix();
            Items_Matrix_Page_View items_matrix = new Items_Matrix_Page_View();

            if (Page > 0)
            {
                items_matrix.Page = Page;
            }


            #region get data from db
            items_matrix.Items_List = itemsList;
            items_matrix.TotalItemsCount = items_matrix.Items_List.Count();
            items_matrix.ItemsPageList = items_matrix.Items_List.ToPagedList(pageNumber, pageSize);
            #endregion

            for (int i = 1; i < 100; i++)
            {
                dishes.Add("noodles");
                dishes.Add("sausage");
                dishes.Add("beans on toast");
                dishes.Add("cheeseburger");
                dishes.Add("battered mars bar");
                dishes.Add("crisp butty");
                dishes.Add("yorkshire pudding");
                dishes.Add("wiener schnitzel");
                dishes.Add("sauerkraut mit ei");
                dishes.Add("onion soup");
                dishes.Add("bak choi");
                dishes.Add("avacado maki");
            }

            dishes_model.Dishes_List = dishes;
            dishes_model.TotalDishesCount = dishes_model.Dishes_List.Count();
            dishes_model.DishesPageList = dishes_model.Dishes_List.ToPagedList(pageNumber, pageSize);

            return Json(dishes_model);
        }

        private List<Items_Matrix> getItemsMatrix()
        {
            List<Items_Matrix> itemsMatrix = new List<Items_Matrix>();
            using (PaginationContext db = new PaginationContext())
            {
                try
                {
                    itemsMatrix = (from t1 in db.Items_Matrix
                                   orderby t1.Items_Matrix_No
                                   select t1).ToList();
                }
                catch (Exception ex)
                {
                    string exMessage = ex.Message;
                }
            }
            return itemsMatrix;
        }

        private List<Items_Matrix> getItemsMatrixByID(Guid clauseMatrixID)
        {
            List<Items_Matrix> itemsMatrix = new List<Items_Matrix>();
            using (PaginationContext db = new PaginationContext())
            {
                try
                {
                    itemsMatrix = (from t1 in db.Items_Matrix
                                   where t1.Clause_Matrix_ID == clauseMatrixID
                                   orderby t1.Items_Matrix_No
                                   select t1).ToList();
                }
                catch (Exception ex)
                {
                    string exMessage = ex.Message;
                }
            }
            return itemsMatrix;
        }
    }
}