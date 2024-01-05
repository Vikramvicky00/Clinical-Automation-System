using DALLayer;

namespace CASTesting
{
    [TestFixture]
    public class AdminTest
    {
        [Test]
        public void EmailIdShouldBeRequired()
        {
            var admin = new Admin { EmailId = null };
            Assert.That(() => ValidateModel(admin), Throws.Exception);
        }

        [Test]
        public void PasswordShouldBeRequired()
        {
            var admin = new Admin { Password = null };
            Assert.That(() => ValidateModel(admin), Throws.Exception);
        }

        private void ValidateModel(Admin admin)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(admin, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(admin, context, results, true);

            if (!isValid)
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
            }
        }
    }
}