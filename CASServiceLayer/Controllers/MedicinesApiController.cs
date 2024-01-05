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
    public class MedicinesApiController : ApiController
    {
        private readonly ServiceOperations service;
        public MedicinesApiController()
        {
            service = new ServiceOperations();
        }

        // GET: api/MedicinesApi
        public List<Medicine> GetMedicines()
        {
            return service.GetAllMedicines();
        }

        // GET: api/MedicinesApi/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult GetMedicine(int id)
        {
            Medicine medicine = service.GetMedicineById(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        // PUT: api/MedicinesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.MedicineId)
            {
                return BadRequest();
            }

            service.UpdateMedicine(medicine);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MedicinesApi
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult PostMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddMedicine(medicine);

            return CreatedAtRoute("DefaultApi", new { id = medicine.MedicineId }, medicine);
        }

        // DELETE: api/MedicinesApi/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult DeleteMedicine(int id)
        {
            Medicine medicine = service.GetMedicineById(id);
            if (medicine == null)
            {
                return NotFound();
            }
            service.DeleteMedicine(id);
            return Ok(medicine);
        }
    }
}