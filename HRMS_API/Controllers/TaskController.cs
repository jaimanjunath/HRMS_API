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
    public class TaskController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();


        // GET: api/UserMaster
        public IQueryable<tblTask> GetTask()
        {
            return db.tblTasks.AsQueryable();
        }

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutTask(string task_id, tblTask task)
        {
            if (task_id != task.TASK_ID)
            {
                return BadRequest();
            }
            db.Entry(task).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(task_id))
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
        private bool TaskExists(string task_id)
        {
            return db.tblTasks.Count(e => e.TASK_ID == task_id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblTask))]
        public IHttpActionResult PostProject(tblTask task)
        {

            db.tblTasks.Add(task);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = task.ID }, task);
        }

        [ResponseType(typeof(tblTask))]
        public IHttpActionResult DeleteTask(int id)
        {
            tblTask objTask = db.tblTasks.Find(id);
            if (objTask == null)
            {
                return NotFound();
            }

            db.tblTasks.Remove(objTask);
            db.SaveChanges();

            return Ok(objTask);
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
