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
        public IQueryable<tblHoliday> GetHoliday(int EmpID)
        {
            DateTime today = DateTime.Today;
            IQueryable<tblHoliday> holiday = from h in db.tblHolidays
                                             join e in db.tblEmployees on h.CITY equals e.CITY
                                             orderby h.HOLIDAY_DATE ascending, h.CITY
                                             where e.ID.Equals(EmpID) && h.HOLIDAY_DATE.Year.Equals(today.Year)
                                             select h;
                                             //join e in db.tblEmployees on h.CITY equals e.CITY // orderby h.HOLIDAY_DATE ascending //,h.CITY
                                             //where e.ID.Equals(EmpID) //&& h.HOLIDAY_DATE.Year.Equals(today.Year)
                                             //select new tblHoliday
                                             //{
                                             //    ID = h.ID,
                                             //    HOLIDAY_NAME = h.HOLIDAY_NAME,
                                             //    HOLIDAY_TYPE = h.HOLIDAY_TYPE,
                                             //    HOLIDAY_DATE = h.HOLIDAY_DATE,
                                             //    HOLIDAY_DAY = h.HOLIDAY_DAY,
                                             //    HOLIDAY_DESC = h.HOLIDAY_DESC,
                                             //    CREATEDBY = h.CREATEDBY,
                                             //    CREATEDON = h.CREATEDON,
                                             //    UPDATEDBY = h.UPDATEDBY,
                                             //    UPDATEDON = h.UPDATEDON,
                                             //    STATUS = h.STATUS,
                                             //    CITY = h.CITY
                                             //};
            return holiday;
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
