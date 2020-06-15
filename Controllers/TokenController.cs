﻿using System;
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
    public class TokenController : ApiController
    {
        private DBModel db = new DBModel();
        public TokenController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Token
        public IQueryable<Token> GetTokens()
        {
            return db.Tokens;
        }

        // GET: api/Token/5
        [ResponseType(typeof(Token))]
        public IHttpActionResult GetToken(int id)
        {
            Token token = db.Tokens.Find(id);
            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);
        }

        // PUT: api/Token/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToken(int id, Token token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != token.tokenId)
            {
                return BadRequest();
            }

            db.Entry(token).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TokenExists(id))
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

        // POST: api/Token
        [ResponseType(typeof(Token))]
        public IHttpActionResult PostToken(Token token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tokens.Add(token);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = token.tokenId }, token);
        }

        // DELETE: api/Token/5
        [ResponseType(typeof(Token))]
        public IHttpActionResult DeleteToken(int id)
        {
            Token token = db.Tokens.Find(id);
            if (token == null)
            {
                return NotFound();
            }

            db.Tokens.Remove(token);
            db.SaveChanges();

            return Ok(token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TokenExists(int id)
        {
            return db.Tokens.Count(e => e.tokenId == id) > 0;
        }
    }
}