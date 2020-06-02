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
    public class ProjectController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();


        // GET: api/UserMaster
        public IQueryable<tblProject> GetProject()
        {
            return db.tblProjects.AsQueryable();
        }

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutProjects(int id, tblProject project)
        {
            if (id != project.ID)
            {
                return BadRequest();
            }
            db.Entry(project).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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
        private bool ProjectExists(int id)
        {
            return db.tblProjects.Count(e => e.ID == id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblProject))]
        public IHttpActionResult PostProject(tblProject project)
        {

            db.tblProjects.Add(project);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = project.ID }, project);
        }

        [ResponseType(typeof(tblProject))]
        public IHttpActionResult DeleteProject(int id)
        {
            tblProject objProject = db.tblProjects.Find(id);
            if (objProject == null)
            {
                return NotFound();
            }

            db.tblProjects.Remove(objProject);
            db.SaveChanges();

            return Ok(objProject);
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
