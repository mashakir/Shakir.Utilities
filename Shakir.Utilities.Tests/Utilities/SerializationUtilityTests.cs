using NUnit.Framework;
using Shakir.Utilities.Extensions;
using Shakir.Utilities.Tests.FakeObjects;
using Shakir.Utilities.Utiltiies;
using Shakir.Utilities.Utiltiies.Interfaces;

namespace Shakir.Utilities.Tests.Utilities
{
    [TestFixture]
    public class SerializationUtilityTests
    {
        private ISerializationUtility _serializationUtility;
        private FakeObjectModel _fakeObjectModel;
        [SetUp]
        public void SetUp()
        {
            _serializationUtility = new SerializationUtility();
            _fakeObjectModel = new FakeObjectModel
            {
                Id = 1,
                Name = "Name"
            };
        }

        [Test]
        public void SerializationShouldReturnCorrectResultInJson()
        { 
            //Action
            var result = _serializationUtility.Serialize(_fakeObjectModel, SerializerType.Json);

            //Assert
            Assert.That(result, Is.TypeOf<string>());
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void SerializationShouldReturnCorrectResultInXml()
        {
            //Action
            var result = _serializationUtility.Serialize(_fakeObjectModel, SerializerType.Xml);

            //Assert
            Assert.That(result, Is.TypeOf<string>());
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void DeserializeShouldReturnCorrectTypeInJson()
        {
            //Arrange 
            var serializedData = _serializationUtility.Serialize(_fakeObjectModel, SerializerType.Json);
            
            //Action
            var result = _serializationUtility.Deserialize<FakeObjectModel>(serializedData, SerializerType.Json);

            //Assert
            Assert.That(result, Is.TypeOf<FakeObjectModel>());
            Assert.That(result.Name, Is.EqualTo(_fakeObjectModel.Name));
            Assert.That(result.Id, Is.EqualTo(_fakeObjectModel.Id));
        }
        [Test]
        public void DeserializeShouldReturnCorrectResultInXml()
        {
            //Arrange 
            var serializedData = _serializationUtility.Serialize(_fakeObjectModel, SerializerType.Xml);

            //Action
            var result = _serializationUtility.Deserialize<FakeObjectModel>(serializedData, SerializerType.Xml);

            //Assert
            Assert.That(result, Is.TypeOf<FakeObjectModel>());
            Assert.That(result.Name,Is.EqualTo(_fakeObjectModel.Name));
            Assert.That(result.Id, Is.EqualTo(_fakeObjectModel.Id));
        }
    }
}
