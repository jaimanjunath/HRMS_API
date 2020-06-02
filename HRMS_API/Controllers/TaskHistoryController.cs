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
using HRMS_API.Models;

namespace HRMS_API.Controllers
{
    public class TaskHistoryController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();


        // GET: api/UserMaster
        public IQueryable<tblTaskHistory> GetTaskHistory()
        {
            return db.tblTaskHistories.AsQueryable();
        }

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutTaskHistory(int task_id, tblTaskHistory taskHistory)
        {
            if (task_id != taskHistory.TASK_ID)
            {
                return BadRequest();
            }
            db.Entry(taskHistory).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskHistoryExists(task_id))
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
        private bool TaskHistoryExists(int task_id)
        {
            return db.tblTaskHistories.Count(e => e.TASK_ID == task_id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblTask))]
        public IHttpActionResult PostProject(tblTaskHistory taskHistory)
        {

            db.tblTaskHistories.Add(taskHistory);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = taskHistory.ID }, taskHistory);
        }

        [ResponseType(typeof(tblTaskHistory))]
        public IHttpActionResult DeleteTask(int id)
        {
            tblTaskHistory objTaskHistory = db.tblTaskHistories.Find(id);
            if (objTaskHistory == null)
            {
                return NotFound();
            }

            db.tblTaskHistories.Remove(objTaskHistory);
            db.SaveChanges();

            return Ok(objTaskHistory);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
