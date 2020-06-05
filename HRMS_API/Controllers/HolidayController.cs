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
    public class HolidayController : ApiController
    {
        private HRMSEntities db = new HRMSEntities();


        // GET: api/UserMaster
        public IQueryable<tblHoliday> GetHoliday()
        {
            return db.tblHolidays.AsQueryable();
        }

        // PUT: api/ColorTemplate/5
        [System.Web.Http.Description.ResponseType(typeof(void))]
        public IHttpActionResult PutHoliday(int id, tblHoliday holiday)
        {
            if (id != holiday.ID)
            {
                return BadRequest();
            }
            db.Entry(holiday).State = EntityState.Modified;
            holiday.HOLIDAY_DAY = holiday.HOLIDAY_DATE.DayOfWeek.ToString();
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayExists(id))
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
        private bool HolidayExists(int id)
        {
            return db.tblHolidays.Count(e => e.ID == id) > 0;
        }
        // POST: api/ColorTemplate
        [ResponseType(typeof(tblHoliday))]
        public IHttpActionResult PostHolidays(tblHoliday holiday)
        {
           
           holiday.HOLIDAY_DAY = holiday.HOLIDAY_DATE.DayOfWeek.ToString();
           

            db.tblHolidays.Add(holiday);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = holiday.ID }, holiday);
        }


        [ResponseType(typeof(tblHoliday))]
        public IHttpActionResult DeleteHoliday(int id)
        {
            tblHoliday objHoliday = db.tblHolidays.Find(id);
            if (objHoliday == null)
            {
                return NotFound();
            }

            db.tblHolidays.Remove(objHoliday);
            db.SaveChanges();

            return Ok(objHoliday);
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
