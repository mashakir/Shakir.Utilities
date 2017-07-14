using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 

namespace Shakir.Utilities.Extensions
{
    public static class ExpressionExtensions
    {
        public static string PropertyName<TSource, TTarget>(this Expression<Func<TSource, TTarget>> expression)
        {
            var memberExpression = (MemberExpression) expression.Body;
            var memberName = memberExpression.Member.Name;

            while (memberExpression.Expression is MemberExpression)
            {
                var parentMemberExpression = (MemberExpression) memberExpression.Expression;
                memberName = string.Concat(parentMemberExpression.Member.Name, ".", memberName);
                memberExpression = parentMemberExpression;
            }

            return memberName;
        }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second,
            Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new {f, s = second.Parameters[i]})
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = LinqParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }

    public class LinqParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        public LinqParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map,
            Expression exp)
        {
            return new LinqParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;

            if (_map.TryGetValue(p, out replacement))
                p = replacement;

            return base.VisitParameter(p);
        }
    }
}