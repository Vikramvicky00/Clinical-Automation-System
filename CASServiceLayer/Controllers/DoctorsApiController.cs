using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CASServiceLayer.Models;
using DALLayer;

namespace CASServiceLayer.Controllers
{

    public class DoctorsApiController : ApiController
    {
        private readonly Service service;//object define
        public DoctorsApiController()
        {
            service = new Service();//object create
        }
        // GET: api/DoctorsApi
        public List<Doctor> GetDoctors()
        {
           
            return service.GetAllDoctors();
        }

        // GET: api/DoctorsApi/5
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult GetDoctor(int id)
        {
            Doctor doctor = service.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // PUT: api/DoctorsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctor(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }

            service.UpdateDoctor(doctor);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DoctorsApi
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult PostDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddDoctor(doctor);  

            return CreatedAtRoute("DefaultApi", new { id = doctor.DoctorId }, doctor);
        }

        // DELETE: api/DoctorsApi/5
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult DeleteDoctor(int id)
        {
            Doctor doctor = service.GetDoctorById(id);//find doctor ,if found it removes ,otherwise notfound
            if (doctor == null)
            {
                return NotFound();
            }

            service.DeleteDoctor(id);
            return Ok(doctor);
        }

    }
}