using DALLayer;

namespace CASTesting
{
    [TestFixture]
  public class PharmacistTest
  {
      [Test]
      public void EmailShouldBeRequired()
      {
          var pharmacist = new Pharmacist { Email = null };
          Assert.That(() => ValidateModel(pharmacist), Throws.Exception);
      }

      [Test]
      public void PasswordShouldBeRequired()
      {
          var pharmacist = new Pharmacist { Password = null };
          Assert.That(() => ValidateModel(pharmacist), Throws.Exception);
      }

      [Test]
      public void GenderShouldBeRequired()
      {
          var pharmacist = new Pharmacist { Gender = null };
          Assert.That(() => ValidateModel(pharmacist), Throws.Exception);
      }

      [Test]
      public void DOBShouldBeRequired()
      {
          var pharmacist = new Pharmacist { DOB = DateTime.MinValue };
          Assert.That(() => ValidateModel(pharmacist), Throws.Exception);
      }

      [Test]
      public void PhoneShouldBeRequired()
      {
          var pharmacist = new Pharmacist { Phone = "0" };
          Assert.That(() => ValidateModel(pharmacist), Throws.Exception);
      }

      [Test]
      public void AddressShouldBeRequired()
      {
          var pharmacist = new Pharmacist { Address = null };
          Assert.That(() => ValidateModel(pharmacist), Throws.Exception);
      }

      // You can add more tests for other properties and validations...

      private void ValidateModel(Pharmacist pharmacist)
      {
          var context = new System.ComponentModel.DataAnnotations.ValidationContext(pharmacist, null, null);
          var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

          bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(pharmacist, context, results, true);

          if (!isValid)
          {
              throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
          }
      }
  }
}
