using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WBS.API.Enums;
using WBS.DAL.Cache;

namespace WBS.API.Helpers
{
    public class QueryHelper
    {
        public static void ApplyConditions<T>(ref IQueryable<T> query, IEnumerable<Filter> filters) where T : class, IBaseEntity
        {
            if (filters == null) return;

            foreach (var filter in filters)
            {
                ParameterExpression paramExpression = Expression.Parameter(typeof(T), "param");
                Expression propValue = Expression.Property(paramExpression, typeof(T).GetProperty(filter.PropertyName));
                Expression filterValue = Expression.Constant(filter.Value);
                Expression resultExpression = null;
                MethodInfo method = null;

                switch (filter.Condition)
                {
                    case FilterCondition.Equal:
                        resultExpression = Expression.Equal(propValue, filterValue);
                        break;
                    case FilterCondition.Less:
                        resultExpression = Expression.LessThan(propValue, filterValue);
                        break;
                    case FilterCondition.LessOrEqual:
                        resultExpression = Expression.LessThanOrEqual(propValue, filterValue);
                        break;
                    case FilterCondition.More:
                        resultExpression = Expression.GreaterThan(propValue, filterValue);
                        break;
                    case FilterCondition.MoreOrEqual:
                        resultExpression = Expression.GreaterThanOrEqual(propValue, filterValue);
                        break;
                    case FilterCondition.Notequal:
                        resultExpression = Expression.NotEqual(propValue, filterValue);
                        break;
                    case FilterCondition.Contains:
                        propValue = Expression.Call(propValue, typeof(String).GetMethods().First(m => m.Name == "ToLower" && m.GetParameters().Length == 0));
                        filterValue = Expression.Constant(filter.Value.ToString().ToLower());
                        method = typeof(string).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Length == 1);
                        resultExpression = Expression.Call(propValue, method, filterValue);
                        break;
                    case FilterCondition.AnyOf:
                        method = typeof(List<int?>).GetMethod("Contains", new Type[] { typeof(int?) });
                        resultExpression = Expression.Call(filterValue, method, propValue); 
                        break;
                    default:
                        throw new Exception("Unsupported condition operator");
                }
                MethodCallExpression whereCallExpression = Expression.Call(
                 typeof(Queryable),
                 "Where",
                 new Type[] { query.ElementType },
                 query.Expression,
                 Expression.Lambda<Func<T, bool>>(resultExpression, new ParameterExpression[] { paramExpression }));

                query = query.Provider.CreateQuery<T>(whereCallExpression);
            }
        }

        public static void ApplySort<T>(ref IQueryable<T> query, Sort sort) where T : class, IBaseEntity
        {
            if (sort == null)
                query = query.OrderBy(f => f.Id);
            else
            {
                var prop = typeof(T).GetProperty(sort.PropertyName); 
                switch (sort.Direction)
                {
                    case SortingDirection.Asc:
                        query = query.OrderBy(f => prop.GetValue(f)).ThenBy(f => f.Id);
                        break;
                    case SortingDirection.Desc:
                        query = query.OrderByDescending(f => prop.GetValue(f)).ThenBy(f => f.Id);
                        break;
                    default:
                        throw new Exception("Unsupported sorting direction value");
                }
            }
        }


    }
}
