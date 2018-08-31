using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WBS.DAL.Enums;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Helpers
{
    public class QueryHelper
    {
        public static IEnumerable<T> ApplyConditions<T>(IEnumerable<T> data, IEnumerable<Filter> filters) where T : class, IBaseEntity
        {
            if (filters == null) return data;

            ParameterExpression paramExpression = Expression.Parameter(typeof(T), "param");
            Func<T, bool> resultPredicate = null;
            Expression resultExpression = null;

            foreach (var filter in filters)
            {
                var propType = typeof(T).GetProperty(filter.PropertyName).PropertyType;
                Expression propValue = Expression.Property(paramExpression, typeof(T).GetProperty(filter.PropertyName));

                Expression expression = null;
                MethodInfo method = null;
                Expression filterValue = null;

                //Если нужное свойство объекта имеет тип Nullable
                if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    var val = Expression.Constant(Convert.ChangeType(filter.Value, propType.GetGenericArguments()[0]));
                    filterValue = Expression.Convert(val, propValue.Type);
                }
                else
                    filterValue = Expression.Constant(filter.Value);

                switch (filter.Condition)
                {
                    case FilterCondition.Equal:
                        expression = Expression.Equal(propValue, filterValue);
                        break;
                    case FilterCondition.Less:
                        expression = Expression.LessThan(propValue, filterValue);
                        break;
                    case FilterCondition.LessOrEqual:
                        expression = Expression.LessThanOrEqual(propValue, filterValue);
                        break;
                    case FilterCondition.More:
                        expression = Expression.GreaterThan(propValue, filterValue);
                        break;
                    case FilterCondition.MoreOrEqual:
                        expression = Expression.GreaterThanOrEqual(propValue, filterValue);
                        break;
                    case FilterCondition.Notequal:
                        expression = Expression.NotEqual(propValue, filterValue);
                        break;
                    case FilterCondition.Contains:
                        propValue = Expression.Call(propValue, typeof(String).GetMethods().First(m => m.Name == "ToLower" && m.GetParameters().Length == 0));
                        filterValue = Expression.Constant(filter.Value.ToString().ToLower());
                        method = typeof(string).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Length == 1);
                        expression = Expression.Call(propValue, method, filterValue);
                        break;
                    case FilterCondition.In:
                        method = typeof(List<int?>).GetMethod("Contains", new Type[] { typeof(int?) });
                        expression = Expression.Call(filterValue, method, propValue);
                        break;
                    default:
                        throw new Exception("Unsupported condition operator");
                }

                //Объединяем условия в одно через AND
                if (resultExpression == null)
                    resultExpression = expression;
                else
                {
                    resultExpression = Expression.AndAlso(
                        Expression.Invoke(Expression.Lambda<Func<T, bool>>(resultExpression, new ParameterExpression[] { paramExpression }), paramExpression),
                        Expression.Invoke(Expression.Lambda<Func<T, bool>>(expression, new ParameterExpression[] { paramExpression }), paramExpression)
                    );
                }
            }

            resultPredicate = Expression.Lambda<Func<T, bool>>(resultExpression, new ParameterExpression[] { paramExpression }).Compile();
            return data.Where(resultPredicate);
        }

        public static IEnumerable<T> ApplySort<T>(IEnumerable<T> data, Sort sort) where T : class, IBaseEntity
        {
            if (sort == null)
                return data.OrderBy(f => f.Id);
            else
            {
                var prop = typeof(T).GetProperty(sort.PropertyName);
                switch (sort.Direction)
                {
                    case SortingDirection.Asc:
                        return data.OrderBy(f => prop.GetValue(f)).ThenBy(f => f.Id);
                    case SortingDirection.Desc:
                        return data.OrderByDescending(f => prop.GetValue(f)).ThenBy(f => f.Id);
                    default:
                        throw new Exception("Unsupported sorting direction value");
                }
            }
        }


    }
}
