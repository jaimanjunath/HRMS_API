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
        public IQueryable<Tasks> GetTask()
        {

            IQueryable<Tasks> task = from t in db.tblTasks
                        join p in db.tblProjects on t.PROJECT_ID equals p.ID
                        join e in db.tblEmployees on t.ASSIGNED_EMP equals e.ID
                        select new
                        Tasks
                        {
                            ID = t.ID,
                            TASK_ID = t.TASK_ID,
                            TASK_SUMMARY = t.TASK_SUMMARY,
                            TASK_DESC = t.TASK_DESC,
                            TASK_TYPE = t.TASK_TYPE,
                            PRIORITY = t.PRIORITY,
                            PROJECT_ID = t.PROJECT_ID,
                            PROJECT = p.PROJECT_NAME,
                            ESTIMATED_HOURS = t.ESTIMATED_HOURS,
                            START_DATE = t.START_DATE,
                            END_DATE = t.END_DATE,
                            DUE_DATE = t.DUE_DATE,
                            ASSIGNED_EMP = t.ASSIGNED_EMP,
                            ASSIGNED = e.USER_NAME,
                            CREATEDBY = t.CREATEDBY,
                            CREATEDON = t.CREATEDON,
                            UPDATEDBY = t.UPDATEDBY,
                            UPDATEDON = t.UPDATEDON,
                            STATUS = t.STATUS
                        };
            return task;

        }
        public IQueryable<Tasks> GetTask(int empid)
        {

            IQueryable<Tasks> task = from t in db.tblTasks
                                     join p in db.tblProjects on t.PROJECT_ID equals p.ID
                                     join e in db.tblEmployees on t.ASSIGNED_EMP equals e.ID
                                     where e.ID.Equals(empid)
                                     select new
                                     Tasks
                                     {
                                         ID = t.ID,
                                         TASK_ID = t.TASK_ID,
                                         TASK_SUMMARY = t.TASK_SUMMARY,
                                         TASK_DESC = t.TASK_DESC,
                                         TASK_TYPE = t.TASK_TYPE,
                                         PRIORITY = t.PRIORITY,
                                         PROJECT_ID = t.PROJECT_ID,
                                         PROJECT = p.PROJECT_NAME,
                                         ESTIMATED_HOURS = t.ESTIMATED_HOURS,
                                         START_DATE = t.START_DATE,
                                         END_DATE = t.END_DATE,
                                         DUE_DATE = t.DUE_DATE,
                                         ASSIGNED_EMP = t.ASSIGNED_EMP,
                                         ASSIGNED = e.USER_NAME,
                                         CREATEDBY = t.CREATEDBY,
                                         CREATEDON = t.CREATEDON,
                                         UPDATEDBY = t.UPDATEDBY,
                                         UPDATEDON = t.UPDATEDON,
                                         STATUS = t.STATUS
                                     };
            return task;

        }

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, tblTask task)
        {
            if (id != task.ID)
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
                if (!TaskExists(id))
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
        private bool TaskExists(int id)
        {
            return db.tblTasks.Count(e => e.ID == id) > 0;
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
