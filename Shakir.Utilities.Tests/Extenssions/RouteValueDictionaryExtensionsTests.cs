using System.Linq;
using System.Web.Routing;
using NUnit.Framework;
using Shakir.Utilities.Extensions;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class RouteValueDictionaryExtensionsTests
    {
        private RouteValueDictionary _routeValueDictionary;

        [SetUp]
        public void SetUp()
        {
            _routeValueDictionary = new RouteValueDictionary();
        }

        [Test]
        public void WithValueShouldReturnCorrectResult()
        {
            //Arrange
            const string key = "key";
            const int value = 213;
            //Action 
            var result = _routeValueDictionary.WithValue(key, value);

            //Assert
            Assert.That(result, Is.TypeOf<RouteValueDictionary>());
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.Keys.First(), Is.EqualTo(key));
            Assert.That(result.Values.First(), Is.EqualTo(value));
        }
    }
}
