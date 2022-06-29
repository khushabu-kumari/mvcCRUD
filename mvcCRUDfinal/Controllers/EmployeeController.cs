using mvcCRUDfinal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCRUDfinal.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        db_testEntities dbObj = new db_testEntities();
        public ActionResult Employee(tbl_Employee obj)
        {
            return View(obj);
            
        }
        [HttpPost]
        public ActionResult AddEmployee(tbl_Employee model)
        {
            tbl_Employee obj = new tbl_Employee();
            if (ModelState.IsValid)
            {
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;

                if (model.ID == 0)
                {
                    dbObj.tbl_Employee.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }

                ModelState.Clear();

            }

            return View("Employee");
        }

        public ActionResult EmployeeList()
        {
            var res = dbObj.tbl_Employee.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbObj.tbl_Employee.Where(x => x.ID == id).First();
            dbObj.tbl_Employee.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tbl_Employee.ToList();
            return View("EmployeeList",list);
        }
	}
}