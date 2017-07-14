using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shakir.Utilities.Extensions;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class EnumerableExtensionTests
    {
        [Test]
        public void DistinctByShouldReturnCorrectDistinctResult()
        {
            //Arrange
            var list = new List<int> {1, 2, 3, 4, 2, 4};

            //Action
            var result = list.DistinctBy(x =>x).ToList();

            //Assert
            Assert.That(result, Is.TypeOf<List<int>>());
            Assert.That(result.Count,Is.EqualTo(4));
            Assert.That(result.First(), Is.EqualTo(1));
            Assert.That(result.Last(), Is.EqualTo(4));
        }
        [Test]
        public void DistinctByShouldReturnCorrectEmptyResult()
        {
            //Arrange
            var list = new List<int> { 1, 2, 3, 4 }; 

            //Action
            var result = list.DistinctBy(x => x).ToList();

            //Assert 
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result.First(), Is.EqualTo(1));
            Assert.That(result.Last(), Is.EqualTo(4));
        }
    }
}
