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
    public class UserMasterController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();


        // GET: api/UserMaster
        public IQueryable<tblUserMaster> GetUserMasters()
        {
            return db.tblUserMasters.AsQueryable();
        }

        // PUT: api/ColorTemplate/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserMasters(int id, tblUserMaster UserMaster)
        {
            if (id != UserMaster.UserID)
            {
                return BadRequest();
            }
            db.Entry(UserMaster).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMastersExists(id))
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
        private bool UserMastersExists(int id)
        {
            return db.tblUserMasters.Count(e => e.UserID == id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblUserMaster))]
        public IHttpActionResult PostColorTemplate(tblUserMaster UserMaster)
        {

            db.tblUserMasters.Add(UserMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = UserMaster.UserID}, UserMaster);
        }
        // DELETE: api/ColorTemplate/5
        [ResponseType(typeof(tblUserMaster))]
        public IHttpActionResult DeleteColorTemplate(int id)
        {
            tblUserMaster objUserMaster = db.tblUserMasters.Find(id);
            if (objUserMaster == null)
            {
                return NotFound();
            }

            db.tblUserMasters.Remove(objUserMaster);
            db.SaveChanges();

            return Ok(objUserMaster);
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
