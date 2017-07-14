using System;
using System.Collections.Generic;
using System.Linq;

namespace Shakir.Utilities.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> ToSafeArray<T>(this IEnumerable<T> input)
        {
            return input ?? Enumerable.Empty<T>();
        }
		
		public static List<T> ToSafeList<T>(this IEnumerable<T> input)
		{
			return input.ToSafeArray().ToList();
		}

        public static bool SequenceSafeEqual<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if (list1 == null && list2 == null) 
                return true;

            if (list1 != null && list2 == null)
                return false;

            return list1 != null && list1.SequenceEqual(list2);
        }

        public static IList<T> AsSafeList<T>(this IEnumerable<T> input)
        {
            var safeArray = input.ToSafeArray();

            return safeArray as IList<T> ?? safeArray.ToList();
        }

        public static int GetOrderDependentHashCode<T>(this IEnumerable<T> list, IEqualityComparer<T> comparer = null)
        {
            if (list == null)
                return 0;

            if (comparer == null)
                comparer = EqualityComparer<T>.Default;

            var hash = 0;

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var item in list)
                hash = hash * 31 + comparer.GetHashCode(item);

            return hash;
        }

        public static IEnumerable<Result> LeftJoin<TOuter, TInner, TKey, Result>(
          this IEnumerable<TOuter> outer, IEnumerable<TInner> inner
          , Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector
          , Func<TOuter, TInner, Result> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (outer == null)
                throw new ArgumentException("outer");

            if (inner == null)
                throw new ArgumentException("inner");

            if (outerKeySelector == null)
                throw new ArgumentException("outerKeySelector");

            if (innerKeySelector == null)
                throw new ArgumentException("innerKeySelector");

            if (resultSelector == null)
                throw new ArgumentException("resultSelector");

            return LeftJoinImpl(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer ?? EqualityComparer<TKey>.Default);
        }

        public static IEnumerable<IEnumerable<TResult>> PartitionBy<TResult>(this IEnumerable<TResult> input, int count)
        {
            if (input == null) throw new ArgumentException("input");
            if (count <= 0) throw new ArgumentException("Parameter should be more than zero", "count");
            var enumerator = input.GetEnumerator();
            var list = new List<TResult>();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
                if (list.Count != count)
                    continue;
                yield return list;
                list = new List<TResult>();
            }
            if (list.Count > 0)
            {
                yield return list;
            }
        }

        #region Private Method
        private static IEnumerable<Result> LeftJoinImpl<TOuter, TInner, TKey, Result>(
            IEnumerable<TOuter> outer, IEnumerable<TInner> inner
            , Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector
            , Func<TOuter, TInner, Result> resultSelector, IEqualityComparer<TKey> comparer)
        {
            var innerLookup = inner.ToLookup(innerKeySelector, comparer);

            foreach (var outerElment in outer)
            {
                var outerKey = outerKeySelector(outerElment);
                var innerElements = innerLookup[outerKey];

                if (innerElements.Any())
                    foreach (var innerElement in innerElements)
                        yield return resultSelector(outerElment, innerElement);
                else
                    yield return resultSelector(outerElment, default(TInner));
            }
        }
        #endregion
    }
}