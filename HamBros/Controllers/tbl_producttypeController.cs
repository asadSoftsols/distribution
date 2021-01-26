using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HamBros.Models;

namespace HamBros.Controllers
{
    public class tbl_producttypeController : Controller
    {
        private HumBrosContext db = new HumBrosContext();

        //
        // GET: /tbl_producttype/

        public ActionResult Index()
        {
            return View(db.tbl_producttype.ToList());
        }

        //
        // GET: /tbl_producttype/Details/5

        public ActionResult Details(int id = 0)
        {
            tbl_producttype tbl_producttype = db.tbl_producttype.Find(id);
            if (tbl_producttype == null)
            {
                return HttpNotFound();
            }
            return View(tbl_producttype);
        }

        //
        // GET: /tbl_producttype/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /tbl_producttype/Create

        [HttpPost]
        public ActionResult Create(tbl_producttype tbl_producttype)
        {
            if (ModelState.IsValid)
            {
                db.tbl_producttype.Add(tbl_producttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_producttype);
        }

        /// <summary>  
        /// Insert New Category  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public string Insert_Category(tbl_producttype category)
        {
            if (category != null)
            {
                var objCat = new tbl_producttype
                {
                    ProductTypeName = category.ProductTypeName,
                    CreateBy = "admin",//Session["user"].ToString(),
                    CreatedAt = DateTime.Now,
                    IsActive = category.IsActive,
                    CompanyId = category.CompanyId,
                    BranchId = category.BranchId,
                    UpdateBy = category.UpdateBy,
                    UpdateAt = DateTime.Now,
                };

                db.tbl_producttype.Add(objCat);
                db.SaveChanges();
                return "Category Added Successfully";

            }
            else
            {
                return "Category Not Inserted! Try Again";
            }
        }

        /// <summary>  
        /// Get Product Type With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult Get_producttypeById(string Id)
        {
            using (HumBrosContext Obj = new HumBrosContext())
            {
                int catId = int.Parse(Id);
                return Json(Obj.tbl_producttype.Find(catId), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>  
        /// Update Product Type Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Update_Category(tbl_producttype cat)
        {
            if (cat != null)
            {
                using (HumBrosContext Obj = new HumBrosContext())
                {
                    var cat_ = Obj.Entry(cat);
                    tbl_producttype catObj = Obj.tbl_producttype.Where(x => x.ProductTypeID == cat.ProductTypeID).FirstOrDefault();
                    catObj.ProductTypeName = cat.ProductTypeName;
                    catObj.IsActive = cat.IsActive;
                    catObj.UpdateBy = "admin";
                    catObj.UpdateAt = DateTime.Now;                   

                    Obj.SaveChanges();
                    return "Category Updated Successfully";
                }
            }
            else
            {
                return "Category Not Updated! Try Again";
            }
        }


        /// <summary>  
        /// Delete Category Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public JsonResult Delete_Category(string id)
        {
            try
            {
                long itemid = long.Parse(id);
                tbl_producttype item = (from t in db.tbl_producttype where t.ProductTypeID == itemid select t).FirstOrDefault();
                db.tbl_producttype.Remove(item);
                db.SaveChanges();
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw;

            }

        }
        //
        // GET: /tbl_producttype/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tbl_producttype tbl_producttype = db.tbl_producttype.Find(id);
            if (tbl_producttype == null)
            {
                return HttpNotFound();
            }
            return View(tbl_producttype);
        }

        //
        // POST: /tbl_producttype/Edit/5

        [HttpPost]
        public ActionResult Edit(tbl_producttype tbl_producttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_producttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_producttype);
        }

        //
        // GET: /tbl_producttype/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tbl_producttype tbl_producttype = db.tbl_producttype.Find(id);
            if (tbl_producttype == null)
            {
                return HttpNotFound();
            }
            return View(tbl_producttype);
        }

        //
        // POST: /tbl_producttype/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_producttype tbl_producttype = db.tbl_producttype.Find(id);
            db.tbl_producttype.Remove(tbl_producttype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}