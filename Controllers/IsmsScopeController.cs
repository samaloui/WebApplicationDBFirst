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
using WebApplicationDBFirst.Models;

namespace WebApplicationDBFirst.Controllers
{
    public class IsmsScopeController : ApiController
    {
        private DBModel db = new DBModel();
        public IsmsScopeController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/IsmsScope
        public IQueryable<IsmsScope> GetIsmsScopes()
        {
            return db.IsmsScopes;
        }

        // GET: api/IsmsScope/5
        [ResponseType(typeof(IsmsScope))]
        public IHttpActionResult GetIsmsScope(int id)
        {
            IsmsScope ismsScope = db.IsmsScopes.Find(id);
            if (ismsScope == null)
            {
                return NotFound();
            }

            return Ok(ismsScope);
        }

        // PUT: api/IsmsScope/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIsmsScope(int id, IsmsScope ismsScope)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ismsScope.ismsId)
            {
                return BadRequest();
            }

            db.Entry(ismsScope).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsmsScopeExists(id))
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

        // POST: api/IsmsScope
        [ResponseType(typeof(IsmsScope))]
        public IHttpActionResult PostIsmsScope(IsmsScope ismsScope)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IsmsScopes.Add(ismsScope);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ismsScope.ismsId }, ismsScope);
        }

        // DELETE: api/IsmsScope/5
        [ResponseType(typeof(IsmsScope))]
        public IHttpActionResult DeleteIsmsScope(int id)
        {
            IsmsScope ismsScope = db.IsmsScopes.Find(id);
            if (ismsScope == null)
            {
                return NotFound();
            }

            db.IsmsScopes.Remove(ismsScope);
            db.SaveChanges();

            return Ok(ismsScope);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IsmsScopeExists(int id)
        {
            return db.IsmsScopes.Count(e => e.ismsId == id) > 0;
        }
    }
}