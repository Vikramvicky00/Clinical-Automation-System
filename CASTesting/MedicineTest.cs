using DALLayer;

namespace CASTesting
{
    [TestFixture]
public class MedicineTests
{
    [Test]
    public void MedicineNameShouldBeRequired()
    {
        var medicine = new Medicine { MedicineName = null };
        Assert.That(() => ValidateModel(medicine), Throws.Exception);
    }

    [Test]
    public void MedicineNameShouldHaveMaxLength()
    {
        var medicine = new Medicine { MedicineName = new string('a', 51) }; // More than 50 characters
        Assert.That(() => ValidateModel(medicine), Throws.Exception);
    }

    [Test]
    public void PriceShouldBeRequired()
    {
        var medicine = new Medicine { Price = 0 };
        Assert.That(() => ValidateModel(medicine), Throws.Exception);
    }

    [Test]
    public void StockShouldBeRequired()
    {
        var medicine = new Medicine { Stock = 0 };
        Assert.That(() => ValidateModel(medicine), Throws.Exception);
    }

    [Test]
    public void TaxShouldBeRequired()
    {
        var medicine = new Medicine { Tax = 0 };
        Assert.That(() => ValidateModel(medicine), Throws.Exception);
    }

    // Test for the dis method (if uncommented)
    //[Test]
    //public void DisShouldCalculateCorrectly()
    //{
    //    var medicine = new Medicine { Price = 100, Tax = 10 };
    //    Assert.AreEqual(90, medicine.dis(medicine.Price, medicine.Tax));
    //}

    private void ValidateModel(Medicine medicine)
    {
        var context = new System.ComponentModel.DataAnnotations.ValidationContext(medicine, null, null);
        var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

        bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(medicine, context, results, true);

        if (!isValid)
        {
            throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
        }
    }
}
}
