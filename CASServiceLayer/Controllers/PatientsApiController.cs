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
    public class PatientsApiController : ApiController
    {
        private readonly Service service;
        public PatientsApiController()
        {
            service = new Service();
        }

        // GET: api/PatientsApi
        public IEnumerable<Patient> GetPatients()
        {
            return service.GetAllPatients();
        }

        // GET: api/PatientsApi/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(int id)
        {
            Patient patient = service.FindPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/PatientsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            service.UpdatePatient(patient);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PatientsApi
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            service.InsertPatient(patient);

            return CreatedAtRoute("DefaultApi", new { id = patient.PatientId }, patient);
        }

        // DELETE: api/PatientsApi/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(int id)
        {
            Patient patient = service.FindPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            service.DeletePatient(id);

            return Ok(patient);
        }

    }
}