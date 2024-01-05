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
    public class PharmacistsApiController : ApiController
    {
        private readonly Service service;
        public PharmacistsApiController()
        {
            service = new Service();
        }
        

        // GET: api/PharmacistsApi
        public List<Pharmacist> GetPharmacists()
        {
            return service.GetAllPharmacists();
        }

        // GET: api/PharmacistsApi/5
        [ResponseType(typeof(Pharmacist))]
        public IHttpActionResult GetPharmacist(int id)
        {
            Pharmacist pharmacist = service.GetPharmacistById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            return Ok(pharmacist);
        }

        // PUT: api/PharmacistsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPharmacist(int id, Pharmacist pharmacist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pharmacist.PharmacistId)
            {
                return BadRequest();
            }

            service.UpdatePharmacist(pharmacist);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PharmacistsApi
        [ResponseType(typeof(Pharmacist))]
        public IHttpActionResult PostPharmacist(Pharmacist pharmacist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddPharmacist(pharmacist);

            return CreatedAtRoute("DefaultApi", new { id = pharmacist.PharmacistId }, pharmacist);
        }

        // DELETE: api/PharmacistsApi/5
        [ResponseType(typeof(Pharmacist))]
        public IHttpActionResult DeletePharmacist(int id)
        {
            Pharmacist pharmacist = service.GetPharmacistById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }

           service.DeletePharmacist(id);

            return Ok(pharmacist);
        }

    }
}