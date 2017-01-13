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
using AsanaApp.Models;
using System.Web.Http.Filters;

namespace AsanaApp.Controllers
{
    public class DepartmentListModelsController : ApiController
    {
        private COMMON_TEST db = new COMMON_TEST();

        // GET: api/DepartmentListModels
        public IQueryable<DepartmentListModels> GetDepartmentListModels()
        {
            return db.DepartmentListModels;
        }


        // GET: api/DepartmentListModels/5
        [ResponseType(typeof(DepartmentListModels))]
        public IHttpActionResult GetDepartmentListModels(int id)
        {
            DepartmentListModels departmentListModels = db.DepartmentListModels.Find(id);
            if (departmentListModels == null)
            {
                return NotFound();
            }

            return Ok(departmentListModels);
        }

        // PUT: api/DepartmentListModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartmentListModels(int id, DepartmentListModels departmentListModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departmentListModels.DEPARTMENT_ID)
            {
                return BadRequest();
            }

            db.Entry(departmentListModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentListModelsExists(id))
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

        // POST: api/DepartmentListModels
        [ResponseType(typeof(DepartmentListModels))]
        public IHttpActionResult PostDepartmentListModels(DepartmentListModels departmentListModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DepartmentListModels.Add(departmentListModels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departmentListModels.DEPARTMENT_ID }, departmentListModels);
        }

        // DELETE: api/DepartmentListModels/5
        [ResponseType(typeof(DepartmentListModels))]
        public IHttpActionResult DeleteDepartmentListModels(int id)
        {
            DepartmentListModels departmentListModels = db.DepartmentListModels.Find(id);
            if (departmentListModels == null)
            {
                return NotFound();
            }

            db.DepartmentListModels.Remove(departmentListModels);
            db.SaveChanges();

            return Ok(departmentListModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentListModelsExists(int id)
        {
            return db.DepartmentListModels.Count(e => e.DEPARTMENT_ID == id) > 0;
        }
    }
}