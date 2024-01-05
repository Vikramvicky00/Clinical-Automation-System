using System.Collections.Generic;
using System.Data.Entity;

namespace DALLayer
{
    public class ClinicalDbContext : DbContext  
    {
       
        public ClinicalDbContext() : base("name = ProjectDB") 
        {
            
        }
               
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<FrontOfficeExecutive> FrontOfficeExecutives { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Specialization> Specializations { get; set; }


    }
}
