using DALLayer;

namespace CASTesting
{
    [TestFixture]
public class PatientTest
{
    [Test]
    public void NameShouldBeRequired()
    {
        var patient = new Patient { Name = null };
        Assert.That(() => ValidateModel(patient), Throws.Exception);
    }

    [Test]
    public void PhoneShouldBeRequired()
    {
        var patient = new Patient { Phone = "0" };
        Assert.That(() => ValidateModel(patient), Throws.Exception);
    }

    [Test]
    public void AddressShouldBeRequired()
    {
        var patient = new Patient { Address = null };
        Assert.That(() => ValidateModel(patient), Throws.Exception);
    }

    [Test]
    public void DOBShouldBeRequired()
    {
        var patient = new Patient { DOB = DateTime.MinValue };
        Assert.That(() => ValidateModel(patient), Throws.Exception);
    }

    [Test]
    public void GenderShouldBeRequired()
    {
        var patient = new Patient { Gender = null };
        Assert.That(() => ValidateModel(patient), Throws.Exception);
    }

    [Test]
    public void EmailShouldBeRequired()
    {
        var patient = new Patient { Email = null };
        Assert.That(() => ValidateModel(patient), Throws.Exception);
    }

    [Test]
    public void PasswordShouldBeRequired()
    {
        var patient = new Patient { Password = null };
        Assert.That(() => ValidateModel(patient), Throws.Exception);
    }

    // You can add more tests for other properties and validations...

    private void ValidateModel(Patient patient)
    {
        // You can use DataAnnotations validation here.
        // For simplicity, this method just checks if the model state is valid.
        // In a real-world application, you might want to use an MVC controller's ModelState.IsValid method
        // or another method to perform validation.
        var context = new System.ComponentModel.DataAnnotations.ValidationContext(patient, null, null);
        var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

        bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(patient, context, results, true);

        if (!isValid)
        {
            throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
        }
    }
}
}
