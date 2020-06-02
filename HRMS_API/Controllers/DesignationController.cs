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
    public class DesignationController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();


        // GET: api/UserMaster
        public IQueryable<tblDesignation> GetDesignationt()
        {
            return db.tblDesignations.AsQueryable();
        }

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutDesignationts(int id, tblDesignation desgination)
        {
            if (id != desgination.ID)
            {
                return BadRequest();
            }
            db.Entry(desgination).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationExists(id))
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
        private bool DesignationExists(int id)
        {
            return db.tblDesignations.Count(e => e.ID == id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblDesignation))]
        public IHttpActionResult PostDesignations(tblDesignation desgination)
        {

            db.tblDesignations.Add(desgination);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = desgination.ID }, desgination);
        }
        // DELETE: api/ColorTemplate/5
        [ResponseType(typeof(tblDesignation))]
        public IHttpActionResult DeleteDesignations(int id)
        {
            tblDesignation objDesignation = db.tblDesignations.Find(id);
            if (objDesignation == null)
            {
                return NotFound();
            }

            db.tblDesignations.Remove(objDesignation);
            db.SaveChanges();

            return Ok(objDesignation);
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

