using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLayer.Repostitory
{
    public class AppointmentRepository
    {
        private readonly ClinicalDbContext _context;
        public AppointmentRepository() 
        {
            _context = new ClinicalDbContext();
        }        
        
        public List<Appointment> GetAllAppointments()
        {
            
            return _context.Appointments.ToList();
        }
        public IEnumerable<Appointment> FindPatientAppointByName(string Name)
        {
            IEnumerable<Appointment> appointments = _context.Appointments.Include("Patient").Where(app => app.Patient.Name.ToLower().Contains(Name.ToLower()) && app.Patient.PatientId==app.PatientId).
                OrderBy(app => app.AppointmentId);
            return appointments;
        }
        public IEnumerable<Appointment> SearchbyPatientIdApproved(int id)
        {
            IEnumerable<Appointment> appointments = _context.Appointments.Include("Patient").
                OrderBy(a => a.AppointmentId).Where(a => a.PatientId == id && a.IsApprove == true);
            return appointments;
            
        }

        public IEnumerable<Appointment> SearchbyDoctorIdApproved(int id)
        {
            IEnumerable<Appointment> appointments = _context.Appointments.Include("Doctor").
                OrderBy(a => a.AppointmentId).Where(a => a.DoctorId == id && a.IsApprove == true);
            return appointments;
        }

        public Appointment GetMsgLimitForSpecificAppoinment(int appointmentId)
        {
            return (Appointment)_context.Appointments
               .Where(a => a.AppointmentId == appointmentId)
                .Select(a => a.MsgLimit);
                
        }


        public Appointment GetAppointmentById(int doc,int pat)
        {
            return _context.Appointments
                .FirstOrDefault(d => d.DoctorId == doc && d.PatientId == pat);
        }
        public Appointment GetAppointmentById(int appointmentId)
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAppointment(int appointmentId)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _context.Appointments
                .Where(a => a.PatientId == patientId)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToList();
        }

        public bool AppointmentExists(int appointmentId)
        {
            return _context.Appointments.Any(a => a.AppointmentId == appointmentId);
        }
    }
}
