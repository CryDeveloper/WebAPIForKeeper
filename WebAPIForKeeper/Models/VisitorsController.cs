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

namespace WebAPIForKeeper.Models
{
    public class VisitorsController : ApiController
    {
        private ATaran_KII_DemExEntities db = new ATaran_KII_DemExEntities();

        // GET: api/Visitors
        [ResponseType(typeof(List<Visitior>))]
        public IHttpActionResult GetVisitors()
        {
            return Ok(db.Visitors.ToList().ConvertAll(x=>new Visitior(x)));
        }

        // GET: api/Visitors/5
        [ResponseType(typeof(Visitors))]
        public IHttpActionResult GetVisitors(int id)
        {
            Visitors visitors = db.Visitors.Find(id);
            if (visitors == null)
            {
                return NotFound();
            }

            return Ok(visitors);
        }

        // PUT: api/Visitors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitors(int id, Visitors visitors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitors.ID_Visitor)
            {
                return BadRequest();
            }

            db.Entry(visitors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorsExists(id))
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

        // POST: api/Visitors
        [ResponseType(typeof(Visitors))]
        public IHttpActionResult PostVisitors(Visitors visitors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visitors.Add(visitors);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visitors.ID_Visitor }, visitors);
        }

        // DELETE: api/Visitors/5
        [ResponseType(typeof(Visitors))]
        public IHttpActionResult DeleteVisitors(int id)
        {
            Visitors visitors = db.Visitors.Find(id);
            if (visitors == null)
            {
                return NotFound();
            }

            db.Visitors.Remove(visitors);
            db.SaveChanges();

            return Ok(visitors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitorsExists(int id)
        {
            return db.Visitors.Count(e => e.ID_Visitor == id) > 0;
        }
    }
}