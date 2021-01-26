using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HamBros.Models
{
    public class HumBrosContext:DbContext
    {
        public HumBrosContext()
            : base("HamBrosConnection") //Connection string name located in web.config file  
        {  
        }

        public DbSet<tbl_producttype> tbl_producttype { get; set; }  //Product Type model as property
        //public DbSet<tbl_ddsr> tbl_ddsr { get; set; }  //Movie model as property
        //public DbSet<Products> Products { get; set; }  //Movie model as property
        //public DbSet<tbl_area> tbl_area { get; set; }
        //public DbSet<Users> USers { get; set; }
        //public DbSet<customers_> customers_ { get; set; }
        //public DbSet<tbl_Salcredit> tbl_Salcredit { get; set; }
        //public DbSet<DSR> DSR { get; set; }
        //public DbSet<tbl_booksalman> tbl_booksalman { get; set; }
        //public DbSet<tbl_Mstk> tbl_Mstk { get; set; }
        //public DbSet<tbl_Dstk> tbl_Dstk { get; set; }
        //public DbSet<STK> STK { get; set; }

    }
}