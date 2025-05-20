using Application.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.Extensions
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> specification)
        {
            return query.Where(specification.ToExpression());
        }
    }
}
