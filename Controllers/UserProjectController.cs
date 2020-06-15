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
    public class UserProjectController : ApiController
    {
        private DBModel db = new DBModel();
        public UserProjectController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/UserProject
        public IQueryable<UserProject> GetUserProjects()
        {
            return db.UserProjects;
        }

        // GET: api/UserProject/5
        [ResponseType(typeof(UserProject))]
        public IHttpActionResult GetUserProject(int id)
        {
            UserProject userProject = db.UserProjects.Find(id);
            if (userProject == null)
            {
                return NotFound();
            }

            return Ok(userProject);
        }

        // PUT: api/UserProject/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserProject(int id, UserProject userProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProject.Id)
            {
                return BadRequest();
            }

            db.Entry(userProject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProjectExists(id))
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

        // POST: api/UserProject
        [ResponseType(typeof(UserProject))]
        public IHttpActionResult PostUserProject(UserProject userProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProjects.Add(userProject);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userProject.Id }, userProject);
        }

        // DELETE: api/UserProject/5
        [ResponseType(typeof(UserProject))]
        public IHttpActionResult DeleteUserProject(int id)
        {
            UserProject userProject = db.UserProjects.Find(id);
            if (userProject == null)
            {
                return NotFound();
            }

            db.UserProjects.Remove(userProject);
            db.SaveChanges();

            return Ok(userProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProjectExists(int id)
        {
            return db.UserProjects.Count(e => e.Id == id) > 0;
        }
    }
}