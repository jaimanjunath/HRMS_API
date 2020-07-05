using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

using HRMS_API.Models;

namespace HRMS_API.Controllers
{
    public class EmployeesController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();


        public IQueryable<tblEmployee> GetEmployee()
        {
            return db.tblEmployees.AsQueryable();
        }
        [HttpGet]
        [ActionName("GetUser")]
        public IQueryable<User> GetUser(string username, string  pwd)
        {
            IQueryable<User> user = from e in db.tblEmployees
                                    where (e.EMAIL.Equals(username) && e.PASSWORD.Equals(pwd))
                                    select new User
                                    {
                                        ID = e.ID,
                                        FIRST_NAME = e.FIRST_NAME,
                                        LAST_NAME = e.LAST_NAME,
                                        USER_NAME = e.USER_NAME,
                                        EMAIL = e.EMAIL,
                                        PASSWORD = e.PASSWORD,
                                        EMP_ID = e.EMP_ID,
                                        PHONE_NUMBER = e.PHONE_NUMBER,
                                        STATUS = e.STATUS,
                                        ROLE = e.ROLE
                                    };
            return user;
            //return db.tblEmployees.AsQueryable();
        }

        //// GET: api/UserMaster
        //public List<tblEmployee> GetEmployee()
        //{
        //    using (HRMSEntities db1 = new HRMSEntities())
        //    {
        //        var emps = db1.tblEmployees.ToList();
        //        if (emps.Any() == false)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return emps;
        //        }

        //    }
        //}

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutEmployees(int id, tblEmployee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }
            db.Entry(employee).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        private bool EmployeeExists(int id)
        {
            return db.tblEmployees.Count(e => e.ID == id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblEmployee))]
        public IHttpActionResult PostEmployeess(tblEmployee employee)
        {

            db.tblEmployees.Add(employee);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        }
        // DELETE: api/ColorTemplate/5
        [ResponseType(typeof(tblEmployee))]
        public IHttpActionResult DeleteEmployeess(int id)
        {
            tblEmployee objEmployee = db.tblEmployees.Find(id);
            if (objEmployee == null)
            {
                return NotFound();
            }

            db.tblEmployees.Remove(objEmployee);
            db.SaveChanges();

            return Ok(objEmployee);
        }
        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}
