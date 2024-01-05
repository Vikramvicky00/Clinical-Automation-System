using System.Collections.Generic;
using System.Data.Entity;

namespace DALLayer
{
    public class ClinicalDbContext : DbContext  //ClincialDbcontext class name , it inherits the Dbcontext(from system.Data.Entity.Dbcontext) to create the database 
    {
        //default constructor to initialize the database //The Name (ProjectDB) and the name in connection string must be same.
        public ClinicalDbContext() : base("name = ProjectDB") //base keyword is used to call the base class constructor(i.e in Dbcontext class constructor)
        {
            
        }
               //DbSet(From Entity)<class> Table name {get set properties}
        public DbSet<Admin> Admins { get; set; } //DbSet is used to create the tables for classes we created 
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
