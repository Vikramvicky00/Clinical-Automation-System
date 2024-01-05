using DALLayer;

namespace CASTesting
{
    [TestFixture]
 public class SpecializationTest
 {
     [Test]
     public void SpecializationNameShouldBeRequired()
     {
         var specialization = new Specialization { SpecializationName = null };
         Assert.That(() => ValidateModel(specialization), Throws.Exception);
     }

     [Test]
     public void SpecializationNameShouldHaveMaxLength()
     {
         var specialization = new Specialization { SpecializationName = new string('a', 51) }; // More than 50 characters
         Assert.That(() => ValidateModel(specialization), Throws.Exception);
     }

     // You can add more tests for other properties and validations...

     private void ValidateModel(Specialization specialization)
     {
         var context = new System.ComponentModel.DataAnnotations.ValidationContext(specialization, null, null);
         var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

         bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(specialization, context, results, true);

         if (!isValid)
         {
             throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
         }
     }
 }
}
