using System;
using System.Threading;
using NUnit.Framework;
using Shakir.Utilities.Retrier;
using Shakir.Utilities.Retrier.Interface;

namespace Shakir.Utilities.Tests.Retrier
{
    [TestFixture]
    public class RetrierTests
    {
        private IRetrier<string> _retrier;

        [SetUp]
        public void SetUp()
        {
            _retrier = new Retrier<string>();
        }

        [Test]
        public void RetrierShouldReturnCorrectResult()
        {
            //Arrange & //Action
            var result = _retrier.TryWithDelay(GetResult, 1, 100);

            //Assert
            Assert.That(result,Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("Result"));
        }

        [Test]
        public void RetrierShouldReturnExceptionAfterNoOfTries()
        {
            //Arrange, Action & Assert
            Assert.Throws<ArgumentException>(() => _retrier.TryWithDelay(ThrowException, 3, 100));
        }
        [Test]
        public void RetrierShouldReturnNullAfterNumberOfTries()
        {
            //Arrange & //Action
            var result = _retrier.TryWithDelay(ReturnNull, 2, 100);

            //Assert 
            Assert.IsNull(result);
        }

        #region Private Method

        private static string GetResult() => "Result";

        private static string ReturnNull()
        {
            Thread.Sleep(10000);
            return null;
        } 
        private static string ThrowException() => throw new ArgumentException("Argument");
        #endregion
    }
}
