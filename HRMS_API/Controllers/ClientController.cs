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
    public class ClientController : ApiController
    {


        private HRMSEntities db = new HRMSEntities();


        // GET: api/UserMaster
        public IQueryable<tblClient> GetClient()
        {
            return db.tblClients.AsQueryable();
        }

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutClients(int id, tblClient Client)
        {
            if (id != Client.ID)
            {
                return BadRequest();
            }
            db.Entry(Client).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
        private bool ClientExists(int id)
        {
            return db.tblClients.Count(e => e.ID == id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblClient))]
        public IHttpActionResult PostClients(tblClient client)
        {

            db.tblClients.Add(client);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = client.ID }, client);
        }
        // DELETE: api/ColorTemplate/5
        [ResponseType(typeof(tblClient))]
        public IHttpActionResult DeleteClients(int id)
        {
            tblClient objClients = db.tblClients.Find(id);
            if (objClients == null)
            {   
                return NotFound();
            }

            db.tblClients.Remove(objClients);
            db.SaveChanges();

            return Ok(objClients);
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

    internal class tblClients
    {
    }
}
