using System;
using NUnit.Framework;
using Shakir.Utilities.Attributes;
using Shakir.Utilities.Attributes.Enums;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class RangeIfAttributeTests
    {
        #region Nested classes

        private class TestIntegerRangeIfAttribute : RangeIfAttribute
        {
            public TestIntegerRangeIfAttribute(int minimum, int maximum, string dependentPropertyName, Relation relation,
                object dependentPropertyRequiredValue)
                : base(minimum, maximum, dependentPropertyName, relation, dependentPropertyRequiredValue)
            {
            }

            public Attribute GetInnerValidationType => ValidationAttribute;
        }

        private class TestDoubleRangeIfAttribute : RangeIfAttribute
        {
            public TestDoubleRangeIfAttribute(double minimum, double maximum, string dependentPropertyName,
                Relation relation, object dependentPropertyRequiredValue)
                : base(minimum, maximum, dependentPropertyName, relation, dependentPropertyRequiredValue)
            {
            }

            public Attribute GetInnerValidationType => ValidationAttribute;
        }

        private class TestTypeRangeIfAttribute : RangeIfAttribute
        {
            public TestTypeRangeIfAttribute(Type type, string minimum, string maximum,
                string dependentPropertyName,
                object dependentPropertyRequiredValue)
                : base(type, minimum, maximum, dependentPropertyName, Relation.Equal, dependentPropertyRequiredValue)
            {
            }

            public Attribute GetInnerValidationType => ValidationAttribute;
        }

        #endregion Nested classes

        #region Test methods

        [Test]
        public void InnerValidationTypeShouldBeNotNullUsingIntegerValues()
        {
            //Arrange & Action
            var validation = new TestIntegerRangeIfAttribute(0, 0, null, Relation.Equal, null);

            //Assert
            Assert.NotNull(validation.GetInnerValidationType);
        }

        [Test]
        public void InnerValidationTypeShouldBeRelationLessThanAttributeUsingIntegerValues()
        {
            //Arrange & Action
            var validation = new TestIntegerRangeIfAttribute(0, 0, null, Relation.Equal, null);

            //Assert
            Assert.IsInstanceOf<System.ComponentModel.DataAnnotations.RangeAttribute>(validation.GetInnerValidationType);
        }

        [Test]
        public void DependentPropertyNameShouldBeSetCorrectlyUsingIntegerValues()
        {
            //Arrange
            const string expectedPropertyName = "expected";

            //Action
            var validation = new TestIntegerRangeIfAttribute(0, 0, expectedPropertyName, Relation.Equal, null);

            //Assert
            Assert.AreEqual(expectedPropertyName, validation.DependentPropertyName);
        }

        [Test]
        public void DependentPropertyRequiredValueShouldBeSetCorrectlyUsingIntegerValues()
        {
            //Arrange
            const string dependentPropertyRequiredValue = "expected";

            //Action
            var validation = new TestIntegerRangeIfAttribute(0, 0, null, Relation.Equal, dependentPropertyRequiredValue);

            //Assert
            Assert.AreEqual(dependentPropertyRequiredValue, validation.DependentPropertyRequiredValue);
        }

        [Test]
        public void InnerValidationTypeShouldBeNotNullUsingDoubleValues()
        {
            //Arrange & Action
            var validation = new TestDoubleRangeIfAttribute(0, 0, null, Relation.Equal, null);

            //Assert
            Assert.NotNull(validation.GetInnerValidationType);
        }

        [Test]
        public void InnerValidationTypeShouldBeRelationLessThanAttributeUsingDoubleValues()
        {
            //Arrange & Action
            var validation = new TestDoubleRangeIfAttribute(0, 0, null, Relation.Equal, null);

            //Assert
            Assert.IsInstanceOf<System.ComponentModel.DataAnnotations.RangeAttribute>(validation.GetInnerValidationType);
        }

        [Test]
        public void DependentPropertyNameShouldBeSetCorrectlyUsingDoubleValues()
        {
            //Arrange
            const string expectedPropertyName = "expected";

            //Action
            var validation = new TestDoubleRangeIfAttribute(0, 0, expectedPropertyName, Relation.Equal, null);

            //Assert
            Assert.AreEqual(expectedPropertyName, validation.DependentPropertyName);
        }

        [Test]
        public void DependentPropertyRequiredValueShouldBeSetCorrectlyUsingDoubleValues()
        {
            //Arrange
            const string dependentPropertyRequiredValue = "expected";

            //Action
            var validation = new TestDoubleRangeIfAttribute(0, 0, null, Relation.Equal, dependentPropertyRequiredValue);

            //Assert
            Assert.AreEqual(dependentPropertyRequiredValue, validation.DependentPropertyRequiredValue);
        }

        [Test]
        public void InnerValidationTypeShouldBeNotNullUsingType()
        {
            //Arrange
            var rangeType = typeof(char);

            //Action
            var validation = new TestTypeRangeIfAttribute(rangeType, null, null, null, null);

            //Assert
            Assert.NotNull(validation.GetInnerValidationType);
        }

        [Test]
        public void InnerValidationTypeShouldBeRelationLessThanAttributeUsingType()
        {
            //Action
            var rangeType = typeof(char);

            //Action
            var validation = new TestTypeRangeIfAttribute(rangeType, null, null, null, null);

            //Assert
            Assert.IsInstanceOf<System.ComponentModel.DataAnnotations.RangeAttribute>(validation.GetInnerValidationType);
        }

        [Test]
        public void DependentPropertyNameShouldBeSetCorrectlyUsingType()
        {
            //Arrange
            const string expectedPropertyName = "expected";
            var rangeType = typeof(char);

            //Action
            var validation = new TestTypeRangeIfAttribute(rangeType, null, null, expectedPropertyName, null);

            //Assert
            Assert.AreEqual(expectedPropertyName, validation.DependentPropertyName);
        }

        [Test]
        public void DependentPropertyRequiredValueShouldBeSetCorrectlyUsingType()
        {
            //Arrange
            const string dependentPropertyRequiredValue = "expected";
            var rangeType = typeof(char);

            //Action
            var validation = new TestTypeRangeIfAttribute(rangeType, null, null, null,
                dependentPropertyRequiredValue);

            //Assert
            Assert.AreEqual(dependentPropertyRequiredValue, validation.DependentPropertyRequiredValue);
        }

        #endregion Test methods
    }
}
