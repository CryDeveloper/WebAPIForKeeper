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
using WebAPIForKeeper.Models;

namespace WebAPIForKeeper.Controllers
{
    public class ApplicationsController : ApiController
    {
        private ATaran_KII_DemExEntities db = new ATaran_KII_DemExEntities();

        // GET: api/Applications
        public IQueryable<Applications> GetApplications()
        {
            return db.Applications;
        }

        // GET: api/Applications/5
        [ResponseType(typeof(Applications))]
        public IHttpActionResult GetApplications(int id)
        {
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return NotFound();
            }

            return Ok(applications);
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplications(int id, Applications applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applications.ID_Application)
            {
                return BadRequest();
            }

            db.Entry(applications).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationsExists(id))
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

        // POST: api/Applications
        [ResponseType(typeof(Applications))]
        public IHttpActionResult PostApplications(Applications applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(applications);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applications.ID_Application }, applications);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(Applications))]
        public IHttpActionResult DeleteApplications(int id)
        {
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return NotFound();
            }

            db.Applications.Remove(applications);
            db.SaveChanges();

            return Ok(applications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationsExists(int id)
        {
            return db.Applications.Count(e => e.ID_Application == id) > 0;
        }
    }
}