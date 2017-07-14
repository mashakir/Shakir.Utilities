using NUnit.Framework;
using Shakir.Utilities.Extensions;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class ModelExtensionsTests
    {
        private FakeObjectModel _fakeObjectModel;
        [SetUp]
        public void SetUp()
        {
            _fakeObjectModel = new FakeObjectModel
            {
                Id = 1,
                Name = "Name"
            };
        } 
        [Test]
        public void CloneObjectShouldReturnCorrectResult()
        {
            //Action
            var result = _fakeObjectModel.DeepClone();

            //Assert
            Assert.That(result, Is.TypeOf<FakeObjectModel>());
            Assert.That(result.Name, Is.EqualTo(_fakeObjectModel.Name));
            Assert.That(result.Id, Is.EqualTo(_fakeObjectModel.Id));
        }

        [Test]
        public void SerializeShouldReturnCorrectResult()
        {
            //Action
            var result = _fakeObjectModel.Serialize();

            //Assert
            Assert.That(result, Is.TypeOf<string>());
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void DeserializeShouldReturnCorrectResult()
        {
            //Arrange
            var serializedData = _fakeObjectModel.Serialize();

            //Action
            var result = serializedData.Deserialize<FakeObjectModel>();

            //Assert
            Assert.That(result, Is.TypeOf<FakeObjectModel>());
            Assert.That(result.Name, Is.EqualTo(_fakeObjectModel.Name));
            Assert.That(result.Id, Is.EqualTo(_fakeObjectModel.Id));
        }
    }
}
