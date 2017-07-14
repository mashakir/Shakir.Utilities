using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Rhino.Mocks;
using Shakir.Utilities.Attributes;
using Shakir.Utilities.Attributes.Enums;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class ConditionalValidationAttributeTests
    {
        #region Fields

        private const string CustomErrorMessage = "CustomErrorMessage";
        private const string DefaultErrorMessage = "DefaultErrorMessage";
        private const string DependentPropertyName = "DependentProperty";
        private readonly object _valueTovalidate = 3;
        private ValidationAttribute _validationAttribute;

        #endregion Fields

        #region Setup

        [SetUp]
        public void SetupContext()
        {
            _validationAttribute = MockRepository.GenerateStub<ValidationAttribute>();
        }

        #endregion Setup

        #region Test methods

        #region Relation Equal tests

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAnExpectedValueNullUsingEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndEqualsToExpectedValueUsingEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndLessThanExpectedValueUsingEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue + 1;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);
            
            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndGreaterThanExpectedValueUsingEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue - 1;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNullAndExpectedValueNotNullUsingEqualRelation()
        {
            //Arrange
            const int dependentPropertyExpectedValue = 1;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfBothDependentPropertyValueAndExpectedValueAreNullUsingEqualRelation()
        {
            //Arrange
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        #endregion Relation Equal tests

        #region Relation Not Equal tests

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAnExpectedValueNullUsingNotEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const Relation relation = Relation.NotEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndEqualsToExpectedValueUsingNotEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.NotEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndLessThanExpectedValueUsingNotEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue + 1;
            const Relation relation = Relation.NotEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndGreaterThanExpectedValueUsingNotEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue - 1;
            const Relation relation = Relation.NotEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNullAndExpectedValueNotNullUsingNotEqualRelation()
        {
            //Arrange
            const int dependentPropertyExpectedValue = 1;
            const Relation relation = Relation.NotEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfBothDependentPropertyValueAndExpectedValueAreNullUsingNotEqualRelation()
        {
            //Action
            const Relation relation = Relation.NotEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        #endregion Relation Not Equal tests

        #region Relation Less Than tests

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAnExpectedValueNullUsingLessThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const Relation relation = Relation.LessThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndEqualsToExpectedValueUsingLessThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.LessThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndLessThanExpectedValueUsingLessThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue + 1;
            const Relation relation = Relation.LessThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndGreaterThanExpectedValueUsingLessThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue - 1;
            const Relation relation = Relation.LessThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNullAndExpectedValueNotNullUsingLessThanRelation()
        {
            //Arrange
            const int dependentPropertyExpectedValue = 1;
            const Relation relation = Relation.LessThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfBothDependentPropertyValueAndExpectedValueAreNullUsingLessThanRelation()
        {
            //Arrange
            const Relation relation = Relation.LessThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        #endregion Relation Less Than tests

        #region Relation Less Than Or Equal tests

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAnExpectedValueNullUsingLessThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const Relation relation = Relation.LessThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);
            
            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndEqualsToExpectedValueUsingLessThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.LessThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndLessThanExpectedValueUsingLessThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue + 1;
            const Relation relation = Relation.LessThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndGreaterThanExpectedValueUsingLessThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue - 1;
            const Relation relation = Relation.LessThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNullAndExpectedValueNotNullUsingLessThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyExpectedValue = 1;
            const Relation relation = Relation.LessThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfBothDependentPropertyValueAndExpectedValueAreNullUsingLessThanOrEqualRelation()
        {
            //Arrange
            const Relation relation = Relation.LessThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        #endregion Relation Less Than Or Equal tests

        #region Relation Greater Than tests

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAnExpectedValueNullUsingGreaterThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const Relation relation = Relation.GreaterThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndEqualsToExpectedValueUsingGreaterThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.GreaterThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndLessThanExpectedValueUsingGreaterThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue + 1;
            const Relation relation = Relation.GreaterThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndGreaterThanExpectedValueUsingGreaterThanRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue - 1;
            const Relation relation = Relation.GreaterThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNullAndExpectedValueNotNullUsingGreaterThanRelation()
        {
            //Arrange
            const int dependentPropertyExpectedValue = 1;
            const Relation relation = Relation.GreaterThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfBothDependentPropertyValueAndExpectedValueAreNullUsingGreaterThanRelation()
        {
            //Arrange
            const Relation relation = Relation.GreaterThan;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        #endregion Relation Less Than tests

        #region Relation Greater Than Or Equal tests

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAnExpectedValueNullUsingGreaterThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const Relation relation = Relation.GreaterThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndEqualsToExpectedValueUsingGreaterThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.GreaterThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNotNullAndLessThanExpectedValueUsingGreaterThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue + 1;
            const Relation relation = Relation.GreaterThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfDependentPropertyValueNotNullAndGreaterThanExpectedValueUsingGreaterThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue - 1;
            const Relation relation = Relation.GreaterThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldNotCallGetValidationResultIfDependentPropertyValueNullAndExpectedValueNotNullUsingGreaterThanOrEqualRelation()
        {
            //Arrange
            const int dependentPropertyExpectedValue = 1;
            const Relation relation = Relation.GreaterThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasNotCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        [Test]
        public void ShouldCallGetValidationResultIfBothDependentPropertyValueAndExpectedValueAreNullUsingGreaterThanOrEqualRelation()
        {
            //Arrange
            const Relation relation = Relation.GreaterThanOrEqual;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = null });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, null });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);

            //Action
            conditionalValidationAttribute.Validate(_valueTovalidate, validationContext);

            //Assert
            _validationAttribute.AssertWasCalled(x => x.GetValidationResult(_valueTovalidate, validationContext));
        }

        #endregion Relation Less Than Or Equal tests

        #region ErrorMessage tests

        [Test]
        public void ShouldValidationResultSuccessIfInnerValidationResultSuccessAndErrorMessageNotSet()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);
            conditionalValidationAttribute.ErrorMessage = null;

            //Action
            var result = conditionalValidationAttribute.GetValidationResult(_valueTovalidate, validationContext);

            //Assert
            Assert.AreEqual(ValidationResult.Success, result);
        }

        [Test]
        public void ShouldValidationResultSuccessIfInnerValidationResultSuccessAndErrorMessageEmpty()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);
            conditionalValidationAttribute.ErrorMessage = string.Empty;

            //Action
            var result = conditionalValidationAttribute.GetValidationResult(_valueTovalidate, validationContext);

            //Assert
            Assert.AreEqual(ValidationResult.Success, result);
        }

        [Test]
        public void ShouldValidationResultSuccessIfInnerValidationResultSuccessAndErrorMessageSet()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(ValidationResult.Success);
            conditionalValidationAttribute.ErrorMessage = CustomErrorMessage;

            //Action
            var result = conditionalValidationAttribute.GetValidationResult(_valueTovalidate, validationContext);

            //Assert
            Assert.AreEqual(ValidationResult.Success, result);
        }

        [Test]
        public void ShouldValidationResultContainsInnerMessageIfInnerValidationResultNotSuccessAndErrorMessageNotSet()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(new ValidationResult(DefaultErrorMessage));
            conditionalValidationAttribute.ErrorMessage = null;

            //Action
            var result = conditionalValidationAttribute.GetValidationResult(_valueTovalidate, validationContext);

            //Assert
            Assert.AreNotEqual(ValidationResult.Success, result);
            Assert.NotNull(result);
            Assert.AreEqual(DefaultErrorMessage, result.ErrorMessage);
        }

        [Test]
        public void ShouldValidationResultContainsInnerMessageIfInnerValidationResultNotSuccessAndErrorMessageEmpty()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(new ValidationResult(DefaultErrorMessage));
            conditionalValidationAttribute.ErrorMessage = string.Empty;

            //Action
            var result = conditionalValidationAttribute.GetValidationResult(_valueTovalidate, validationContext);

            //Assert
            Assert.AreNotEqual(ValidationResult.Success, result);
            Assert.NotNull(result);
            Assert.AreEqual(DefaultErrorMessage, result.ErrorMessage);
        }

        [Test]
        public void ShouldValidationResultContainsCustomMessageIfInnerValidationResultNotSuccessAndErrorMessageSet()
        {
            //Arrange
            const int dependentPropertyValue = 10;
            const int dependentPropertyExpectedValue = dependentPropertyValue;
            const Relation relation = Relation.Equal;
            var validationContext = new ValidationContext(new FakeObjectModel { DependentProperty = dependentPropertyValue });
            var conditionalValidationAttribute =
                MockRepository.GeneratePartialMock<ConditionalValidationAttribute>(new object[] { _validationAttribute, DependentPropertyName, string.Empty, relation, dependentPropertyExpectedValue });
            _validationAttribute.Stub(x => x.GetValidationResult(_valueTovalidate, validationContext))
                .Return(new ValidationResult(DefaultErrorMessage));
            conditionalValidationAttribute.ErrorMessage = CustomErrorMessage;

            //Action
            var result = conditionalValidationAttribute.GetValidationResult(_valueTovalidate, validationContext);

            //Assert
            Assert.AreNotEqual(ValidationResult.Success, result);
            Assert.NotNull(result);
            Assert.AreEqual(CustomErrorMessage, result.ErrorMessage);
        }

        #endregion ErrorMessage tests

        #endregion Test methods
    }
}
