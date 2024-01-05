using DALLayer;

namespace CASTesting
{
    [TestFixture]
public class AppointmentTest
{
    [Test]
    public void StartDateTimeShouldBeRequired()
    {
        var appointment = new Appointment { StartDateTime = default };
        Assert.That(() => ValidateModel(appointment), Throws.Exception);
    }

    [Test]
    public void StatusShouldHaveMaxLength()
    {
        var appointment = new Appointment { Status = new string('a', 11) }; // More than 10 characters
        Assert.That(() => ValidateModel(appointment), Throws.Exception);
    }

    [Test]
    public void DetailsShouldHaveMaxLength()
    {
        var appointment = new Appointment { Details = new string('a', 201) }; // More than 200 characters
        Assert.That(() => ValidateModel(appointment), Throws.Exception);
    }

    [Test]
    public void PatientIdShouldBeRequired()
    {
        var appointment = new Appointment { PatientId = 0 };
        Assert.That(() => ValidateModel(appointment), Throws.Exception);
    }

    [Test]
    public void DoctorIdShouldBeRequired()
    {
        var appointment = new Appointment { DoctorId = 0 };
        Assert.That(() => ValidateModel(appointment), Throws.Exception);
    }

    // You can add more tests for other properties and validations...

    private void ValidateModel(Appointment appointment)
    {
        var context = new System.ComponentModel.DataAnnotations.ValidationContext(appointment, null, null);
        var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

        bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(appointment, context, results, true);

        if (!isValid)
        {
            throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
        }
    }
}
}
