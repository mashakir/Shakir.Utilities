using System.Collections.Generic;
using NUnit.Framework;
using Shakir.Utilities.BatchGenerators;
using Shakir.Utilities.BatchGenerators.Interfaces;

namespace Shakir.Utilities.Tests.BatchGenerators
{
    [TestFixture]
    public class BatchGeneratorTests
    {
        private IBatchGenerator _batchGenerator;

        [SetUp]
        public void SetUp()
        {
            _batchGenerator = new BatchGenerator();
        }

        [Test]
        public void GetItemsInBatchesShouldReturnCorrectTypeIfTypeIsInt()
        {
            //Arrange
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};

            //Action
            var result = _batchGenerator.GetItemsInBatches(list, 2);

            //Assert
            Assert.That(result, Is.TypeOf<List<List<int>>>());
        }

        [Test]
        public void GetItemsInBatchesShouldReturnCorrectTypeIfTypeIsString()
        {
            //Arrange
            var list = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8"};

            //Action
            var result = _batchGenerator.GetItemsInBatches(list, 2);

            //Assert
            Assert.That(result, Is.TypeOf<List<List<string>>>());
        }

        [Test]
        public void GetItemsInBatchesShouldReturnCorrectTypeIfTypeIsDto()
        {
            //Arrange
            var list = new List<TestDto> {new TestDto(), new TestDto(), new TestDto(), new TestDto()};

            //Action
            var result = _batchGenerator.GetItemsInBatches(list, 2);

            //Assert
            Assert.That(result, Is.TypeOf<List<List<TestDto>>>());
        }

        [Test]
        public void GetItemsInBatchesShouldReturnCorrectResultIfSameItemDivision()
        {
            //Arrange
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};

            //Action
            var result = _batchGenerator.GetItemsInBatches(list, 2);

            //Assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0].Count, Is.EqualTo(2));
            Assert.That(result[0][0], Is.EqualTo(1));
            Assert.That(result[0][1], Is.EqualTo(2));
            Assert.That(result[1].Count, Is.EqualTo(2));
            Assert.That(result[1][0], Is.EqualTo(3));
            Assert.That(result[1][1], Is.EqualTo(4));
            Assert.That(result[2].Count, Is.EqualTo(2));
            Assert.That(result[2][0], Is.EqualTo(5));
            Assert.That(result[2][1], Is.EqualTo(6));
            Assert.That(result[3].Count, Is.EqualTo(2));
            Assert.That(result[3][0], Is.EqualTo(7));
            Assert.That(result[3][1], Is.EqualTo(8));
        }

        [Test]
        public void GetItemsInBatchesShouldReturnCorrectResultIfDifferentDivision()
        {
            //Arrange
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7};

            //Action
            var result = _batchGenerator.GetItemsInBatches(list, 2);

            //Assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0].Count, Is.EqualTo(2));
            Assert.That(result[0][0], Is.EqualTo(1));
            Assert.That(result[0][1], Is.EqualTo(2));
            Assert.That(result[1].Count, Is.EqualTo(2));
            Assert.That(result[1][0], Is.EqualTo(3));
            Assert.That(result[1][1], Is.EqualTo(4));
            Assert.That(result[2].Count, Is.EqualTo(2));
            Assert.That(result[2][0], Is.EqualTo(5));
            Assert.That(result[2][1], Is.EqualTo(6));
            Assert.That(result[3].Count, Is.EqualTo(1));
            Assert.That(result[3][0], Is.EqualTo(7));
        }

        private class TestDto
        {
        }
    }
}
