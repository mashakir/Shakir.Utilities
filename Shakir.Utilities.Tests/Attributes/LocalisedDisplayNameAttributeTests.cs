using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Shakir.Utilities.Attributes;
using Shakir.Utilities.Tests.FakeObjects;
using Shakir.Utilities.Utiltiies;

namespace Shakir.Utilities.Tests.Attributes
{
    public class LocalisedDisplayNameAttributeTests
    { 
        [Test]
        public void LocalisedDisplayNameAttributeShouldReturnCorrectResult()
        { 
            //Action
            var result = new LocalisedDisplayNameAttribute("DisplayName", typeof(FakeResource));

            //Assert
            Assert.That(result.DisplayName, Is.TypeOf<string>()); 
            Assert.That(result.DisplayName, Is.EqualTo(FakeResource.DisplayName));
        }
    }
}
