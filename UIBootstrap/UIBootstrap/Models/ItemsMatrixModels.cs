using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UIBootstrap.Models
{
    public class Items_Matrix
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Items_Matrix_ID { get; set; }
        public Guid Clause_Matrix_ID { get; set; }
        public double Items_Matrix_No { get; set; }
        public string Items_Matrix_Description { get; set; }
        public DateTime? Items_Matrix_Created_Date { get; set; }
        public Guid? Items_Matrix_Created_By { get; set; }
        public DateTime? Items_Matrix_Modified_Date { get; set; }
        public Guid? Items_Matrix_Modified_By { get; set; }
    }

    public class Items_Matrix_Page_View
    {
        public List<Items_Matrix> Items_List { get; set; }

        // Pagination
        public int? Page { get; set; }
        public int TotalItemsCount { get; set; }
        public IPagedList<Items_Matrix> ItemsPageList { get; set; }
    }
}