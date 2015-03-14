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
using wwwdrivesafe.Models;

namespace wwwdrivesafe.Controllers
{
    public class Location_Log_Sync_Controller : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Location_Log_Sync_
        public IQueryable<Location_Log> GetLocation_Logs()
        {
            return db.Location_Logs;
        }

        // GET: api/Location_Log_Sync_/5
        [ResponseType(typeof(Location_Log))]
        public IHttpActionResult GetLocation_Log(int id)
        {
            Location_Log location_Log = db.Location_Logs.Find(id);
            if (location_Log == null)
            {
                return NotFound();
            }

            return Ok(location_Log);
        }

        // PUT: api/Location_Log_Sync_/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocation_Log(int id, Location_Log location_Log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location_Log.Id)
            {
                return BadRequest();
            }

            db.Entry(location_Log).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Location_LogExists(id))
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

        // POST: api/Location_Log_Sync_
        [ResponseType(typeof(Location_Log))]
        public IHttpActionResult PostLocation_Log([FromBody] Location_Log location_Log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			location_Log.SyncDate = DateTime.Now;
            db.Location_Logs.Add(location_Log);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = location_Log.Id }, location_Log);
        }

        // DELETE: api/Location_Log_Sync_/5
        [ResponseType(typeof(Location_Log))]
        public IHttpActionResult DeleteLocation_Log(int id)
        {
            Location_Log location_Log = db.Location_Logs.Find(id);
            if (location_Log == null)
            {
                return NotFound();
            }

            db.Location_Logs.Remove(location_Log);
            db.SaveChanges();

            return Ok(location_Log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Location_LogExists(int id)
        {
            return db.Location_Logs.Count(e => e.Id == id) > 0;
        }
    }
}