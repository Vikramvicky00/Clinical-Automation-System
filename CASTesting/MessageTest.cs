using DALLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASTesting
{
   [TestFixture]
public class MessageTests
{
    [Test]
    public void MessageTimeShouldBeRequired()
    {
        var message = new Message { MessageTime = default };
        Assert.That(() => ValidateModel(message), Throws.Exception);
    }

    [Test]
    public void Message1ShouldBeRequired()
    {
        var message = new Message { Message1 = null };
        Assert.That(() => ValidateModel(message), Throws.Exception);
    }

    [Test]
    public void Message1ShouldHaveMaxLength()
    {
        var message = new Message { Message1 = new string('a', 201) }; // More than 200 characters
        Assert.That(() => ValidateModel(message), Throws.Exception);
    }

    [Test]
    public void StatusShouldBeRequired()
    {
        var message = new Message { Status = null };
        Assert.That(() => ValidateModel(message), Throws.Exception);
    }

    [Test]
    public void StatusShouldHaveMaxLength()
    {
        var message = new Message { Status = new string('a', 101) }; // More than 100 characters
        Assert.That(() => ValidateModel(message), Throws.Exception);
    }

    [Test]
    public void ReceiverIdShouldBeRequired()
    {
        var message = new Message { ReceiverId = 0 };
        Assert.That(() => ValidateModel(message), Throws.Exception);
    }

    [Test]
    public void SenderIdShouldBeRequired()
    {
        var message = new Message { SenderId = 0 };
        Assert.That(() => ValidateModel(message), Throws.Exception);
    }

    private void ValidateModel(Message message)
    {
        var context = new System.ComponentModel.DataAnnotations.ValidationContext(message, null, null);
        var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

        bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(message, context, results, true);

        if (!isValid)
        {
            throw new System.ComponentModel.DataAnnotations.ValidationException(results[0].ErrorMessage);
        }
    }
}
}
