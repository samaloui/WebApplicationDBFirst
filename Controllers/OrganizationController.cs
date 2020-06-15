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
    public class OrganizationController : ApiController
    {
        private DBModel db = new DBModel();
        public OrganizationController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Organization
        public IQueryable<Organization> GetOrganizations()
        {
            return db.Organizations;
        }

        // GET: api/Organization/5
        [ResponseType(typeof(Organization))]
        public IHttpActionResult GetOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        // PUT: api/Organization/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganization(int id, Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organization.organizationId)
            {
                return BadRequest();
            }

            db.Entry(organization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
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

        // POST: api/Organization
        [ResponseType(typeof(Organization))]
        public IHttpActionResult PostOrganization(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organizations.Add(organization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organization.organizationId }, organization);
        }

        // DELETE: api/Organization/5
        [ResponseType(typeof(Organization))]
        public IHttpActionResult DeleteOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            db.Organizations.Remove(organization);
            db.SaveChanges();

            return Ok(organization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationExists(int id)
        {
            return db.Organizations.Count(e => e.organizationId == id) > 0;
        }
    }
}