using DALLayer;

namespace CASTesting
{
    [TestFixture]
public class FrontOfficeExecutiveTests
{
    [Test]
    public void EmailShouldBeRequired()
    {
        var executive = new FrontOfficeExecutive { Email = null };
        Assert.That(() => ValidateModel(executive), Throws.Exception);
    }

    [Test]
    public void PasswordShouldBeRequired()
    {
        var executive = new FrontOfficeExecutive { Password = null };
        Assert.That(() => ValidateModel(executive), Throws.Exception);
    }

    [Test]
    public void DOBShouldBeRequired()
    {
        var executive = new FrontOfficeExecutive { DOB = DateTime.MinValue };
        Assert.That(() => ValidateModel(executive), Throws.Exception);
    }

    [Test]
    public void PhoneShouldBeRequired()
    {
        var executive = new FrontOfficeExecutive { Phone = "0" };
        Assert.That(() => ValidateModel(executive), Throws.Exception);
    }

    [Test]
    public void GenderShouldBeRequired()
    {
        var executive = new FrontOfficeExecutive { Gender = null };
        Assert.That(() => ValidateModel(executive), Throws.Exception);
    }

    [Test]
    public void AddressShouldBeRequired()
    {
        var executive = new FrontOfficeExecutive { Address = null };
        Assert.That(() => ValidateModel(executive), Throws.Exception);
    }

    // You can add more tests for other properties and validations...

    private void ValidateModel(FrontOfficeExecutive executive)
    {
        var context = new System.ComponentModel.DataAnnotations.ValidationContext(executive, null, null);
        var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

        bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(executive, context, results, true);

        if (!isValid)
        {
            throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
        }
    }
}
}
