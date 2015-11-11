using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgetTheMilk.Controllers;


namespace ConsolVerification
{
    using NUnit.Framework;

    public class LinkValidationTests : AssertionHelper
    {
        [Test]
        public void Validate_InvalidUrl_ThrowsException()
        {
            var invalidLink = "http://www.doesnotexistdotcom.com";

            Expect(() => new LinkValidator().Validate(invalidLink),
                Throws.Exception.With.Message.EqualTo("Invalid link " + invalidLink));
        }

        [Test]
        public void Validate_ValidUrl_DoesNotThrowException()
        {
            var validLink = "http://www.google.com";

            Expect(() => new LinkValidator().Validate(validLink), 
                Throws.Nothing);
        }

    }
}
