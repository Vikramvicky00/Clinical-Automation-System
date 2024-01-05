using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace DALLayer.Repostitory
{
    public class PatientRepository //class name
    {
        private ClinicalDbContext _Db; //define database class object

        public PatientRepository() 
        {
            _Db = new ClinicalDbContext(); //intialize database object 
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _Db.Patients.ToList(); //used to get all data of patients;
        }
                                 //int   b 
                    //methodname  class object name
        public void InsertPatient(Patient patient)
        {
            _Db.Patients.Add(patient);
            Save();
        }
        public void UpdatePatient(Patient patient)
        {
            _Db.Entry(patient).State = EntityState.Modified;
            Save();
        }
        public bool checkPatientLogin(Patient patient)
        {
            return _Db.Patients.Any(d => d.Email == patient.Email && d.Password == patient.Password);
        }
        public void DeletePatient(int id)
        {
            Patient found = _Db.Patients.Find(id);
            if (found != null)
            {
                _Db.Patients.Remove(found);
                Save();
            }
        }
        public void Save()
        {
            _Db.SaveChanges();
        }
        public Patient FindPatientById(int id)
        {
            return _Db.Patients.Find(id); // select * from patients where patientId=id;
        }
        public Patient FindPatientByName(string Email)
        {
            return _Db.Patients.FirstOrDefault(pro => pro.Email == Email); //select * from patients where patientEmail=Email;
        }
              //datatype
        public IEnumerable<Patient> FindPatientWithName(string Name)
        {
            return _Db.Patients.Where(meds => meds.Name.ToLower().Contains(Name.ToLower()));
        }   //select * from patients where lower(patientname)=lower(name);
    }
}
