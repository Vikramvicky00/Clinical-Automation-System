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
using CASServiceLayer.Models;
using DALLayer;

namespace CASServiceLayer.Controllers
{
    public class FrontOfficeExecutivesApiController : ApiController
    {
        private readonly Service service;
        public FrontOfficeExecutivesApiController()
        {
            service = new Service();
        }

        // GET: api/FrontOfficeExecutivesApi
        public List<FrontOfficeExecutive> GetFrontOfficeExecutives()
        {
            return service.GetAllFrontOfficeExecutives();
        }

        // GET: api/FrontOfficeExecutivesApi/5
        [ResponseType(typeof(FrontOfficeExecutive))]
        public IHttpActionResult GetFrontOfficeExecutive(int id)
        {
            FrontOfficeExecutive frontOfficeExecutive = service.GetFrontOfficeExecutiveById(id);
            if (frontOfficeExecutive == null)
            {
                return NotFound();
            }

            return Ok(frontOfficeExecutive);
        }

        // PUT: api/FrontOfficeExecutivesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFrontOfficeExecutive(int id, FrontOfficeExecutive frontOfficeExecutive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != frontOfficeExecutive.FrontOffExecutiveId)
            {
                return BadRequest();
            }

          service.UpdateFrontOfficeExecutive(frontOfficeExecutive);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FrontOfficeExecutivesApi
        [ResponseType(typeof(FrontOfficeExecutive))]
        public IHttpActionResult PostFrontOfficeExecutive(FrontOfficeExecutive frontOfficeExecutive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddFrontOfficeExecutive(frontOfficeExecutive);

            return CreatedAtRoute("DefaultApi", new { id = frontOfficeExecutive.FrontOffExecutiveId }, frontOfficeExecutive);
        }

        // DELETE: api/FrontOfficeExecutivesApi/5
        [ResponseType(typeof(FrontOfficeExecutive))]
        public IHttpActionResult DeleteFrontOfficeExecutive(int id)
        {
            FrontOfficeExecutive frontOfficeExecutive = service.GetFrontOfficeExecutiveById(id);
            if (frontOfficeExecutive == null)
            {
                return NotFound();
            }

            service.DeleteFrontOfficeExecutive(id);

            return Ok(frontOfficeExecutive);
        }

    }
}