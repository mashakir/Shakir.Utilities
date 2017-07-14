using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shakir.Utilities.Extensions;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class ArrayExtensionsTest
    {
        #region ToSafeArray
        [Test]
        public void ToSafeArrayShouldReturnEmptyArrayForNull()
        {
            //Action
            var result = ((int[]) null).ToSafeArray();

            //Assert
            Assert.IsEmpty(result);
            Assert.IsInstanceOf(typeof(Array), result);
        }

        [Test]
        public void ToSafeArrayShouldReturnSameArrayIfNotNull()
        {
            //Arrange
            var array = Enumerable.Range(0, 10).ToArray();

            //Action
            var result = array.ToSafeArray();

            //Assert
            Assert.AreEqual(array, result);
            Assert.IsInstanceOf(typeof(Array), result);
        }

        [Test]
        public void ToSafeArrayShouldReturnSameListIfNotNull()
        {
            //Arrange
            var array = Enumerable.Range(0, 10).ToList();

            //Action
            var result = array.ToSafeArray();

            //Assert
            Assert.AreEqual(array, result);
            Assert.IsInstanceOf(typeof(List<int>), result);
        }
        #endregion

        #region LeftJoin

        [Test]
        public void LeftJoinShouldRaiseExceptionIfTOuterIsNull()
        {
            //Arrange
            var inner = new[] { Tuple.Create(1, "1"), Tuple.Create(2, "2"), Tuple.Create(3, "3") };

            //Action & Assert
            Assert.Throws<ArgumentException>(
                () => ((Tuple<int, string>[]) null).LeftJoin(inner, x => x.Item1, y => y.Item1, (x, y) => new { x, y }, EqualityComparer<int>.Default));
        }

        [Test]
        public void LeftJoinShouldRaiseExceptionIfTInnerIsNull()
        {
            //Arrange
            var outer = new[] { Tuple.Create(1, "1"), Tuple.Create(2, "2"), Tuple.Create(3, "3") };
            
            //Action & Assert
            Assert.Throws<ArgumentException>(
                () => outer.LeftJoin((Tuple<int, string>[]) null, x => x.Item1, y => y.Item1, (x, y) => new { x, y }, EqualityComparer<int>.Default));
        }

        [Test]
        public void LeftJoinShouldRaiseExceptionIfOuterKeySelectorIsNull()
        {
            //Arrange
            var outer = new[] { Tuple.Create(1, "1"), Tuple.Create(2, "2"), Tuple.Create(3, "3") };
            var inner = new[] { Tuple.Create(1, "11"), Tuple.Create(2, "22") };

            //Action & Assert
            Assert.Throws<ArgumentException>(
                () => outer.LeftJoin(inner, null, y => y.Item1, (x, y) => new { x, y }, EqualityComparer<int>.Default));
        }

        [Test]
        public void LeftJoinShouldRaiseExceptionIfInnerKeySelectorIsNull()
        {
            //Arrange
            var outer = new[] { Tuple.Create(1, "1"), Tuple.Create(2, "2"), Tuple.Create(3, "3") };
            var inner = new[] { Tuple.Create(1, "11"), Tuple.Create(2, "22") };

            //Action & Assert
            Assert.Throws<ArgumentException>(
                () => outer.LeftJoin(inner, x => x.Item1, null, (x, y) => new { x, y }, EqualityComparer<int>.Default));
        }

        [Test]
        public void LeftJoinShouldRaiseExceptionIfResultSelectorIsNull()
        {
            //Arrange
            var outer = new[] { Tuple.Create(1, "1"), Tuple.Create(2, "2"), Tuple.Create(3, "3") };
            var inner = new[] { Tuple.Create(1, "11"), Tuple.Create(2, "22") };

            //Action & Assert
            Assert.Throws<ArgumentException>(
                () => outer.LeftJoin(inner, x => x.Item1, y => y.Item1, (Func<Tuple<int, string>, Tuple<int, string>, Tuple<int, string, int, string>>) null, EqualityComparer<int>.Default));
        }

        [Test]
        public void LeftJoinShouldReturnProperResult()
        {
            //Arrange
            var outer = new[] { Tuple.Create(1, "1"), Tuple.Create(2, "2"), Tuple.Create(3, "3") };
            var inner = new[] { Tuple.Create(1, "11"), Tuple.Create(2, "22") };

            //Action
            var result = outer.LeftJoin(inner, x => x.Item1, y => y.Item1, (x, y) => Tuple.Create(x.Item1, x.Item2, y != null ? y.Item2 : null), EqualityComparer<int>.Default).ToList();

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[2].Item3, Is.Null);
        }
        #endregion

        #region PartitionBy

        [Test]
        public void PartitionByShouldReturnProperResult()
        {
            //Arrange
            var input = new[] { 1, 2, 3, 4, 5 };
            
            //Action
            var result = input.PartitionBy(3).ToArray();

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0].SequenceEqual(new[] { 1, 2, 3 }));
            Assert.That(result[1].SequenceEqual(new[] { 4, 5 }));
        }

        [Test]
        public void PartitionByShouldThrowExceptionWhenInputIsNull()
        {
            //Action & Assert
            Assert.Throws<ArgumentException>(
                () => ((IEnumerable<int>)null).PartitionBy(1).ToSafeList());
        }

        [Test]
        public void PartitionByShouldThrowExceptionWhenCountIsNegative()
        {
            //Arrange
            var input = new[] { 1, 2, 3, 4, 5 };

            //Action & Assert
            Assert.Throws<ArgumentException>(
                () => input.PartitionBy(0).ToSafeList());
        }
        #endregion

        #region HashCode

        [Test]
        public void GetOrderDependentHashCodeShouldWorkWhenListIsNull()
        {
            //Action & Assert
            Assert.That(((IEnumerable<string>) null).GetOrderDependentHashCode(), Is.EqualTo(0));
        }

        [Test]
        public void GetOrderDependentHashCodeShouldWorkWithEmptyList()
        {
            //Action & Assert
            Assert.That(new List<string>().GetOrderDependentHashCode(), Is.EqualTo(0));
        }

        [Test]
        public void GetOrderDependentHashCodeShouldGenerateDifferentHasCodeWhenElementOrderIsDiffers()
        {
            //Arrange
            var list1 = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var list2 = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            //Action & Assert
            Assert.That(list1.GetOrderDependentHashCode() == list2.GetOrderDependentHashCode(), Is.False);
        }

        [Test]
        public void GetOrderDependentHashCodeShouldGenerateSameHasCodeWhenElementOrderIsTheSame()
        {
            //Arrange
            var list1 = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var list2 = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            //Action & Assert
            Assert.That(list1.GetOrderDependentHashCode() == list2.GetOrderDependentHashCode(), Is.True);
        }

        #endregion

        #region SequenceSafeEqual

        [Test]
        public void SequenceSafeEqualShuldReturnTrueIfBothListsAreNull()
        {
            //Action
            var result = ArrayExtensions.SequenceSafeEqual<string>(null, null);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void SequenceSafeEqualShuldReturnFalseIfInputIsNull()
        {
            //Arrange
            IEnumerable<string> param1 = new List<string>();

            //Action
            var result = param1.SequenceSafeEqual(null);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void SequenceSafeEqualShuldReturnFalseIfListIsNull()
        {
            //Arrange
            IEnumerable<string> param2 = new List<string>();

            //Action
            var result = ArrayExtensions.SequenceSafeEqual(null, param2);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void SequenceSafeEqualShuldReturnTrueWhenParamsAreEquals()
        {
            //Arrange
            IEnumerable<string> param1 = new List<string>(new[] { "Monday", "Tuesday" });
            IEnumerable<string> param2 = new List<string>(new[] { "Monday", "Tuesday" });

            //Action
            var result = param1.SequenceSafeEqual(param2);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void SequenceSafeEqualShuldReturnFalseWhenParamsAreDiffers()
        {
            //Arrange
            IEnumerable<string> param1 = new List<string>(new[] { "Monday", "Tuesday" });
            IEnumerable<string> param2 = new List<string>(new[] { "Tuesday", "Monday" });

            //Action
            var result = param1.SequenceSafeEqual(param2);

            //Assert
            Assert.That(result, Is.False);
        }

        #endregion
    }
}
