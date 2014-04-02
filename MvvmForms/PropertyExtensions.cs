using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MvvmForms
{
    public static class MvxPropertyNameExtensionMethods
    {
        private const string WrongExpressionMessage =
            "Wrong expression\nshould be called with expression like\n() => PropertyName";
        private const string WrongUnaryExpressionMessage =
            "Wrong unary expression\nshould be called with expression like\n() => PropertyName";

        public static string GetPropertyNameFromExpression<TResult>(
            this object target,
            Expression<Func<TResult>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var memberExpression = FindMemberExpression(expression);

            if (memberExpression == null)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            var member = memberExpression.Member as PropertyInfo;
            if (member == null)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            if (member.DeclaringType == null)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            if (target != null)
            {
                if (!member.DeclaringType.IsAssignableFrom(target.GetType()))
                {
                    throw new ArgumentException(WrongExpressionMessage, "expression");
                }
            }

            if (member.GetGetMethod(true).IsStatic)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            return member.Name;
        }
        public static string GetPropertyNameFromExpression<TIn, TResult>(
            this object target,
            Expression<Func<TIn, TResult>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var memberExpression = FindMemberExpression(expression);

            if (memberExpression == null)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            var member = memberExpression.Member as PropertyInfo;
            if (member == null)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            if (member.DeclaringType == null)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            if (target != null)
            {
                if (!member.DeclaringType.IsAssignableFrom(target.GetType()))
                {
                    throw new ArgumentException(WrongExpressionMessage, "expression");
                }
            }

            if (member.GetGetMethod(true).IsStatic)
            {
                throw new ArgumentException(WrongExpressionMessage, "expression");
            }

            return member.Name;
        }

        private static MemberExpression FindMemberExpression<TIn, TResult>(Expression<Func<TIn, TResult>> expression)
        {
            if (expression.Body is UnaryExpression)
            {
                var unary = (UnaryExpression)expression.Body;
                var member = unary.Operand as MemberExpression;
                if (member == null)
                    throw new ArgumentException(WrongUnaryExpressionMessage, "expression");
                return member;
            }

            return expression.Body as MemberExpression;
        }

        private static MemberExpression FindMemberExpression<TResult>(Expression<Func<TResult>> expression)
        {
            if (expression.Body is UnaryExpression)
            {
                var unary = (UnaryExpression)expression.Body;
                var member = unary.Operand as MemberExpression;
                if (member == null)
                    throw new ArgumentException(WrongUnaryExpressionMessage, "expression");
                return member;
            }

            return expression.Body as MemberExpression;
        }

        public static PropertyInfo GetPropertyInfoFromExpression<TResult>(
            this object target,
            Expression<Func<TResult>> expression)
        {
            var name = GetPropertyNameFromExpression(target, expression);
            return target.GetPropertyInfo(name);
        }

        public static PropertyInfo GetPropertyInfoFromExpression<TIn, TResult>(
            this object target,
            Expression<Func<TIn, TResult>> expression)
        {
            var name = GetPropertyNameFromExpression(target, expression);
            return target.GetPropertyInfo(name);
        }

        public static PropertyInfo GetPropertyInfo(this object target, string name)
        {
            return target.GetType().GetProperty(name);
        }
    }
}
