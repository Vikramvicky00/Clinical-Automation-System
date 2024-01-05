using DALLayer;
using DALLayer.Repostitory;
using System.Collections.Generic;

namespace CASServiceLayer.Models
{
    public class ServiceOperations
    {
        private readonly DoctorRepository _doctor;      //object define
        private readonly PatientRepository _patient;
        private readonly PharmacistRepository _pharmacist;
        private readonly FrontOfficeRepository _frontOffice;
        private readonly MedicineRepository _medicine;
        private readonly AppointmentRepository _appointment;
        private readonly MessageRepository _message;

        public ServiceOperations()
        {    //object =new ClassName();
            _doctor = new DoctorRepository();   //object creation
            _patient = new PatientRepository();
            _pharmacist = new PharmacistRepository();
            _frontOffice = new FrontOfficeRepository();
            _appointment = new AppointmentRepository();
            _medicine = new MedicineRepository();
            _message=new MessageRepository();
        }
        /* Doctors Service Methods*/
        public List<Doctor> GetAllDoctors()
        {
            return _doctor.GetAllDoctors();
        }

        public bool Checkpass(string p1,string p2)//logic for pass
        {
            if (p1 == p2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Login check-----------------------------
        public bool checkAdminLogin(Admin admin)
        {
            return _medicine.checkAdminLogin(admin);
        }
        public bool checkDoctorLogin(Doctor doctor)
        {
            return _doctor.checkDoctorLogin(doctor);
        }

        public bool checkPatientLogin(Patient patient)
        {
            return _patient.checkPatientLogin(patient);
        }
        public bool checkFOLogin(FrontOfficeExecutive FO)
        {
            return _frontOffice.checkFOLogin(FO);
        }
        public bool checkPharmacistLogin(Pharmacist pharmacist)
        {
            return _pharmacist.checkPharmistLogin(pharmacist);
        }
        //-------------------------------
        ///
        public Doctor FindDoctorByEmail(string mail)//name FindDoctorByEmail()
        {
            return _doctor.FindDoctorByEmail(mail);
        }
        public Doctor GetDoctorById(int doctorId)
        {
            return _doctor.GetDoctorById(doctorId);
        }
        public void UpdateAdmin(Admin admin)
        {
           _medicine.UpdateAdmin(admin);
        }
        public void AddDoctor(Doctor doctor)
        {
            _doctor.AddDoctor(doctor);
        }
        public void UpdateDoctor(Doctor doctor)
        {
            _doctor.UpdateDoctor(doctor);
          
        }
        public void DeleteDoctor(int doctorId)
        {
           _doctor.DeleteDoctor(doctorId);
            
        }
        public bool DoctorExists(int doctorId)
        {
            return _doctor.DoctorExists(doctorId);
        }

        /* Patients Methods */
     
        public IEnumerable<Patient> GetAllPatients()
        {
            return _patient.GetAllPatients();
        }
        public void InsertPatient(Patient patient)//required all data to update and insert , so we passes patient class as object.
        {
            _patient.InsertPatient(patient);
            
        }
        public void UpdatePatient(Patient patient)
        {
            _patient.UpdatePatient(patient);
           
        }
        public void DeletePatient(int id)
        {
           _patient.DeletePatient(id);  
            
        }
                      //Function Name
        public Patient FindPatientById(int id)
        {
            return _patient.FindPatientById(id);
        }
        public Patient FindPatientByEmail(string Email)
        {
            return _patient.FindPatientByEmail(Email);
        }
        
        /* Front Office Executive Methods */
        public List<FrontOfficeExecutive> GetAllFrontOfficeExecutives()
        {
            return _frontOffice.GetAllFrontOfficeExecutives();
        }
        public FrontOfficeExecutive FindFrontOfficeByEmail(string Email)
        {
            return _frontOffice.FindFrontOfficeByEmail(Email);
        }
        public FrontOfficeExecutive GetFrontOfficeExecutiveById(int frontOfficeExecutiveId)
        {
            return _frontOffice.GetFrontOfficeExecutiveById((int)frontOfficeExecutiveId);
        }
        public void AddFrontOfficeExecutive(FrontOfficeExecutive frontOfficeExecutive)
        {
            _frontOffice.AddFrontOfficeExecutive(frontOfficeExecutive);
            
        }
        public void UpdateFrontOfficeExecutive(FrontOfficeExecutive frontOfficeExecutive)
        {
            _frontOffice.UpdateFrontOfficeExecutive(frontOfficeExecutive);
            
        }
        public void DeleteFrontOfficeExecutive(int frontOfficeExecutiveId)
        {
            _frontOffice.DeleteFrontOfficeExecutive(frontOfficeExecutiveId);
            
        }
        public bool FrontOfficeExecutiveExists(int frontOfficeExecutiveId)
        {
            return _frontOffice.FrontOfficeExecutiveExists(frontOfficeExecutiveId);
        }

        /* Pharmacist Methods */
        public List<Pharmacist> GetAllPharmacists()
        {
            return _pharmacist.GetAllPharmacists();
        }
        public Pharmacist GetPharmacistById(int pharmacistId)
        {
            return _pharmacist.GetPharmacistById(pharmacistId);
        }
        public void AddPharmacist(Pharmacist pharmacist)
        {
            _pharmacist.AddPharmacist(pharmacist);
        }
        public  Pharmacist FindPharmacistByEmail(string email)
        {
            return _pharmacist.FindPharmacistByEmail(email);
        }

        public void UpdatePharmacist(Pharmacist pharmacist)
        {
           _pharmacist.UpdatePharmacist(pharmacist) ;
        }
        public void DeletePharmacist(int pharmacistId)
        {
            _pharmacist.DeletePharmacist(pharmacistId);
        }
        public bool PharmacistExists(int pharmacistId)
        {
            return _pharmacist.PharmacistExists(pharmacistId); 
        }

        /* Medicine Methods */
        public List<Medicine> GetAllMedicines()
        {
            return _medicine.GetAllMedicines();
        }

        public Medicine GetMedicineById(int medicineId)
        {
            return _medicine.GetMedicineById(medicineId);
        }
        public IEnumerable<Medicine> FindMedicineByName(string Name)
        {
            return _medicine.FindMedicineByName(Name);
        }
        public void AddMedicine(Medicine medicine)
        {
            _medicine.AddMedicine(medicine);
        }
        public void UpdateMedicine(Medicine medicine)
        {
           _medicine.UpdateMedicine(medicine); 
        }




        public Admin FindAdminByEmail(string mail)
        {
            return _medicine.FindAdminByEmail(mail);
        }

        public void DeleteMedicine(int medicineId)
        {
           _medicine.DeleteMedicine(medicineId);
        }
        public float CalculateDiscountedPrice(float price, float tax)
        {
            return _medicine.CalculateDiscountedPrice(price,tax);
        }

        /* Message Methods */
        public Message GetMessageById(int messageId)
        {
            return _message.GetMessageById(messageId);
        }
        public IEnumerable<Message> GetById(int id)
        {
            return _message.GetById(id);
        }
        public IEnumerable<Message> GetBySenderIdAndRecieverId(int SenderId, int RecieverId)
        {
            
            return _message.GetBySenderIdAndRecieverId(SenderId,RecieverId);
        }
        public void AddMessage(Message message)
        {
            _message.AddMessage(message);
        }
        public void UpdateMessage(Message message)
        {
           _message.UpdateMessage(message);
        }
        public void DeleteMessage(int messageId)
        {
            _message.DeleteMessage(messageId);
        }

        /* Appointments Methods */

        public List<Appointment> GetAllAppointments()
        {
            return _appointment.GetAllAppointments();
        }
        public IEnumerable<Appointment> SearchbyPatientIdApproved(int id)
        {
            return _appointment.SearchbyPatientIdApproved(id);
        }
        public IEnumerable<Appointment> SearchbyDoctorIdApproved(int id)
        {
            return _appointment.SearchbyDoctorIdApproved(id);
        }
        public IEnumerable<Appointment> FindPatientAppointByName(string Name)
        {
            return _appointment.FindPatientAppointByName(Name);
        }
        public Appointment GetAppointmentById(int appointmentId)
        {
            return _appointment.GetAppointmentById(appointmentId);
        }
        public void AddAppointment(Appointment appointment)
        {
            _appointment.AddAppointment(appointment);
        }
        public void UpdateAppointment(Appointment appointment)
        {
           _appointment.UpdateAppointment(appointment);
        }
        public void DeleteAppointment(int appointmentId)
        {
           _appointment.DeleteAppointment(appointmentId);
        }
        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _appointment.GetAppointmentsByPatientId(patientId);
        }
        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _appointment.GetAppointmentsByDoctorId(doctorId);
        }
        public bool AppointmentExists(int appointmentId)
        {
            return _appointment.AppointmentExists(appointmentId); 
        }

        public Appointment GetAppointmentByDocPat(int doc, int pat)
        {
            return _appointment.GetAppointmentById(doc, pat);
        }
        public Appointment GetMsgLimitForSpecificAppoinment(int appointmentId)
        {
            return _appointment.GetMsgLimitForSpecificAppoinment(appointmentId) ;

        }
    }
}