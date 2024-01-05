using DALLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASTesting
{
     [TestFixture]
 public class DoctorTest
 {
     [Test]
     public void DoctorNameShouldBeRequired()
     {
         var doctor = new Doctor { DoctorName = null };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void EmailShouldBeRequired()
     {
         var doctor = new Doctor { Email = null };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void PasswordShouldBeRequired()
     {
         var doctor = new Doctor { Password = null };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void GenderShouldBeRequired()
     {
         var doctor = new Doctor { Gender = null };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void DOBShouldBeRequired()
     {
         var doctor = new Doctor { DOB = DateTime.MinValue };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void PhoneShouldBeRequired()
     {
         var doctor = new Doctor { Phone = "0" };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void AddressShouldBeRequired()
     {
         var doctor = new Doctor { Address = null };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void SpecializationIdShouldBeRequired()
     {
         var doctor = new Doctor { SpecializationId = 0 };
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     [Test]
     public void TimingsShouldHaveMaxLength()
     {
         var doctor = new Doctor { Timings = new string('a', 51) }; // More than 50 characters
         Assert.That(() => ValidateModel(doctor), Throws.Exception);
     }

     // You can add more tests for other properties and validations...

     private void ValidateModel(Doctor doctor)
     {
         var context = new System.ComponentModel.DataAnnotations.ValidationContext(doctor, null, null);
         var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

         bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(doctor, context, results, true);

         if (!isValid)
         {
             throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
         }
     }
 }
}
