using HRMS_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HRMS_API.Controllers
{
    
    public class LeaveController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();

        public IQueryable<tblLeaves> GetLeave()
        {
            return db.tblLeaves.AsQueryable();
        }
        public IQueryable<Leave> GetLeaveByEmp(int EmpID)
        {
            IQueryable<Leave> leaves = from l in db.tblLeaves
                                       join e in db.tblEmployees on l.EMP_ID equals e.ID
                                       where e.ID.Equals(EmpID)
                                       select new Leave
                                       {
                                           ID = l.ID,
                                           EMP_ID = l.EMP_ID,
                                           EMP_Name = e.USER_NAME,
                                           LEAVE_TYPE = l.LEAVE_TYPE,
                                           LEAVE_STATUS = l.LEAVE_STATUS,
                                           START_DATE = l.START_DATE,
                                           END_DATE = l.END_DATE,
                                           IS_HALFDAY = l.IS_HALFDAY,
                                           REMARK = l.REMARK,
                                           NUMBER_DAYS = l.NUMBER_DAYS,
                                           CREATEDBY = l.CREATEDBY,
                                           CREATEDON = l.CREATEDON,
                                           UPDATEDBY = l.UPDATEDBY,
                                           UPDATEDON = l.UPDATEDON,
                                           STATUS = l.STATUS
                                       };
            return leaves;
        }

        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutLeave(int id, tblLeaves leave)
        {
            if (id != leave.ID)
            {
                return BadRequest();
            }
            db.Entry(leave).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
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
        private bool LeaveExists(int id)
        {
            return db.tblLeaves.Count(e => e.ID == id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblLeaves))]
        public IHttpActionResult PostLeave(tblLeaves leave)
        {

            db.tblLeaves.Add(leave);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = leave.ID }, leave);
        }

        // DELETE: api/ColorTemplate/5
        [ResponseType(typeof(tblLeaves))]
        public IHttpActionResult DeleteLeave(int id)
        {
            tblLeaves objLeave = db.tblLeaves.Find(id);
            if (objLeave == null)
            {
                return NotFound();
            }

            db.tblLeaves.Remove(objLeave);
            db.SaveChanges();

            return Ok(objLeave);
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
