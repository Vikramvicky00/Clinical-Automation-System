namespace DALLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DALLayer.ClinicalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DALLayer.ClinicalDbContext context)
        {
            //For Adding the Default Data into the database
            base.Seed(context);

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Patients', RESEED, 100)");
            //  //this line is used to the start the patients table from 100 value. 

            //  //Admin
            context.Admins.Add(new Admin { EmailId = "admin@CAS.com", Password = "Admin@CAS6" });
            //our db class.Table name.Add(object of the table class {properties of table class})

            //Default Medicine
            context.Medicines.Add(new Medicine { MedicineName = "Aspirin", Stock = 10, Price = 60, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Paracetamol", Stock = 5, Price = 10, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Naproxen", Stock = 52, Price = 25, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Aspirinol", Stock = 60, Price = 45, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Feveron", Stock = 20, Price = 18, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Dolo 650", Stock = 5, Price = 40, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Cetirizine", Stock = 10, Price = 20, Tax = 5, IsAvailable = true });
            context.Medicines.Add(new Medicine { MedicineName = "Formost 400", Stock = 25, Price = 250, Tax = 5, IsAvailable = true });
            context.SaveChanges();


            context.FrontOfficeExecutives.Add(new FrontOfficeExecutive { Name = "FrontOffCAS", DOB = DateTime.Parse("20-04-1998"), Address = "madras", Gender = "Male", Email = "frontoffice@CAS.com", Password = "Front@CAS6", Phone = "2345678910" });

            context.Pharmacists.Add(new Pharmacist { Name = "Pharmacist", DOB = DateTime.Parse("20-07-1998"), Address = "Chennai", Gender = "Male", Email = "pharmacist@CAS.com", Password = "Pharmacist@CAS6", Phone = "2345678910" });

            //default Specializations for doctors
            //Method-1
            //Specialization specialization = new Specialization() { SpecializationName="dummy"};
            //context.Specializations.Add(specialization);

            ////Method-2
            context.Specializations.Add(new Specialization { SpecializationName = "Neurologist" });
            context.Specializations.Add(new Specialization { SpecializationName = "Dentist" });
            context.Specializations.Add(new Specialization { SpecializationName = "Psychlatrists" });
            context.Specializations.Add(new Specialization { SpecializationName = "Cardiologist" });
            context.Specializations.Add(new Specialization { SpecializationName = "Physicians" });
            context.SaveChanges();

            //default doctors
            context.Doctors.Add(new Doctor { DoctorName = "Anil", DOB = DateTime.Parse("20-04-1995"), Email = "anil@CAS.com", Password = "Anil@CAS6", Address = "Hyderabad", Gender = "Male", Phone = "8587464286", IsAvailable = true, Timings = "11:00 AM - 1:00 PM", SpecializationId = 1 });
            context.Doctors.Add(new Doctor { DoctorName = "Surya", DOB = DateTime.Parse("06-03-1995"), Email = "surya@CAS.com", Password = "Surya@CAS6", Address = "Kadapa", Gender = "Male", Phone = "9865327842", IsAvailable = true, Timings = "09:00 AM - 11:00 AM", SpecializationId = 3 });
            context.Doctors.Add(new Doctor { DoctorName = "Raja Kumar", DOB = DateTime.Parse("05-09-1995"), Email = "raja@CAS.com", Password = "Raja@CAS6", Address = "Hyderabad", Gender = "Male", Phone = "8587464286", IsAvailable = true, Timings = "2:00 PM - 4:00 PM", SpecializationId = 4 });
            context.Doctors.Add(new Doctor { DoctorName = "Shyam", DOB = DateTime.Parse("24-07-1993"), Email = "shyam@CAS.com", Password = "shyam@CAS6", Address = "Chennai", Gender = "Male", Phone = "7848572578", IsAvailable = true, Timings = "04:00 PM - 6:00 PM", SpecializationId = 5 });
            context.Doctors.Add(new Doctor { DoctorName = "Swathi", DOB = DateTime.Parse("12-08-1994"), Email = "anil@CAS.com", Password = "Swathi@CAS6", Address = "Andhra", Gender = "FeMale", Phone = "7707858238", IsAvailable = true, Timings = "09:00 AM - 12:00 PM", SpecializationId = 2 });
            context.SaveChanges();

        }
    }
}
