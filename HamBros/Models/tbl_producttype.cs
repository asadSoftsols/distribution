using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HamBros.Models
{
    public class tbl_producttype
    {
        [Key]
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}