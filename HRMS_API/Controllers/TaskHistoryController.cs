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
        public IQueryable<TaskHistory> GetTaskHistory()
        {

            IQueryable<TaskHistory> taskHistorylist = from t in db.tblTaskHistories
                                                      join e in db.tblEmployees on t.CREATEDBY equals e.ID 
                                                      select new TaskHistory
                                                      {
                                                          ID = t.ID,
                                                          TASK_COMMENTS = t.TASK_COMMENTS,
                                                          TASK_ID = t.TASK_ID,
                                                          CREATEDBY = t.CREATEDBY,
                                                          CREATEDBY_NAME = e.USER_NAME,
                                                          CREATEDON = t.CREATEDON,
                                                          UPDATEDBY = t.UPDATEDBY,
                                                          UPDATEDBY_NAME = e.USER_NAME,
                                                          UPDATEDON = t.UPDATEDON,
                                                          STATUS = t.STATUS                                                      
                                                      };
            //return db.tblTaskHistories.AsQueryable();
            return taskHistorylist;
        }
        public IQueryable<TaskHistory> GetTaskHistory(int taskid)
        {
            //return db.tblTaskHistories.Where(e => e.TASK_ID == taskid).AsQueryable();
            IQueryable<TaskHistory> taskHistorylist = from t in db.tblTaskHistories
                                                      join e in db.tblEmployees on t.CREATEDBY equals e.ID where t.TASK_ID.Equals(taskid)
                                                      orderby t.CREATEDON descending
                                                      select new TaskHistory
                                                      {
                                                          ID = t.ID,
                                                          TASK_COMMENTS = t.TASK_COMMENTS,
                                                          TASK_ID = t.TASK_ID,
                                                          CREATEDBY = t.CREATEDBY,
                                                          CREATEDBY_NAME = e.USER_NAME,
                                                          CREATEDON = t.CREATEDON,
                                                          UPDATEDBY = t.UPDATEDBY,
                                                          UPDATEDBY_NAME = e.USER_NAME,
                                                          UPDATEDON = t.UPDATEDON,
                                                          STATUS = t.STATUS
                                                      };            
            return taskHistorylist;
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
        [ResponseType(typeof(tblTaskHistory))]
        public IHttpActionResult PostTaskHistory(tblTaskHistory taskHistory)
        {
            tblTaskHistory objTaskHistory = new tblTaskHistory();
            objTaskHistory.TASK_COMMENTS = taskHistory.TASK_COMMENTS;
            objTaskHistory.TASK_ID = taskHistory.TASK_ID;
            objTaskHistory.CREATEDBY = taskHistory.CREATEDBY;
            objTaskHistory.CREATEDON = System.DateTime.Now;
            objTaskHistory.UPDATEDBY = taskHistory.UPDATEDBY;
            objTaskHistory.UPDATEDON = System.DateTime.Now;
            objTaskHistory.STATUS = taskHistory.STATUS;


            db.tblTaskHistories.Add(objTaskHistory);
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
