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
    public class AndroidUserInfoSyncController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AndroidUserInfoSync
        public IQueryable<AndroidUserInfo> GetAndroidUserInfo()
        {
            return db.AndroidUserInfo;
        }

        // GET: api/AndroidUserInfoSync/5
        [ResponseType(typeof(AndroidUserInfo))]
        public IHttpActionResult GetAndroidUserInfo(int id)
        {
            AndroidUserInfo androidUserInfo = db.AndroidUserInfo.Find(id);
            if (androidUserInfo == null)
            {
                return NotFound();
            }

            return Ok(androidUserInfo);
        }

        // PUT: api/AndroidUserInfoSync/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAndroidUserInfo(int id, AndroidUserInfo androidUserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != androidUserInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(androidUserInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AndroidUserInfoExists(id))
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

        // POST: api/AndroidUserInfoSync
        [ResponseType(typeof(AndroidUserInfo))]
        public IHttpActionResult PostAndroidUserInfo(AndroidUserInfo androidUserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AndroidUserInfo.Add(androidUserInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = androidUserInfo.ID }, androidUserInfo);
        }

        // DELETE: api/AndroidUserInfoSync/5
        [ResponseType(typeof(AndroidUserInfo))]
        public IHttpActionResult DeleteAndroidUserInfo(int id)
        {
            AndroidUserInfo androidUserInfo = db.AndroidUserInfo.Find(id);
            if (androidUserInfo == null)
            {
                return NotFound();
            }
            db.AndroidUserInfo.Remove(androidUserInfo);
            db.SaveChanges();

            return Ok(androidUserInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AndroidUserInfoExists(int id)
        {
            return db.AndroidUserInfo.Count(e => e.ID == id) > 0;
        }
    }
}