using NUnit.Framework;
using Shakir.Utilities.Anonimisers;

namespace Shakir.Utilities.Tests.Anonimisers
{
    [TestFixture]
    public class AnonimiserTests
    {
        private Anonimiser _anonimiser;
        [SetUp]
        public void SetUp()
        {
            _anonimiser = new Anonimiser();
        }
        [Test]
        public void AnonimiseShouldReturnAnonymousUser()
        {
            //Arrange
            var userName = string.Empty; 

            //Action
            var result = _anonimiser.Anonimise(userName);

            //Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void AnonimiseShouldReturnAnonymousUserContaineActualUser()
        {
            //Arrange
            const string userName = "DeveloperBob@Hotmail.co.uk";

            //Action
            var result = _anonimiser.Anonimise(userName);

            //Assert
            Assert.AreEqual("D************************k", result);
        }
    }
}
