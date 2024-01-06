using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLayer.Repostitory
{
    public class DoctorRepository
    {
        private readonly ClinicalDbContext _context;
        public DoctorRepository() 
        {
            _context = new ClinicalDbContext();
        }


        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _context.Doctors
                .Include(d => d.Specialization)
                .FirstOrDefault(d => d.DoctorId == doctorId);
        }


        public Doctor FindDoctorByEmail(string mail)
        {                                             
            return _context.Doctors.FirstOrDefault(m => m.Email.ToLower() == mail.ToLower());
        }


        public bool checkDoctorLogin(Doctor doctor)
        {
            return _context.Doctors.Any(d => d.Email == doctor.Email && d.Password == doctor.Password);
        }
        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);  
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }

 
        public bool DoctorExists(int doctorId)
        {
            return _context.Doctors.Any(d => d.DoctorId == doctorId);
        }
    }
}
