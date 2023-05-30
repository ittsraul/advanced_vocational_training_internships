using System;
using WebApplication1.Application;
using Microsoft.Extensions.Primitives;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace WebApplication1.infraestructure.Specs
{
    public class SpecificationParser
    {
        public class SpecificationParser<T>:ISpecificationParser<T> where T : class
        {
            public Specification<T> ParseSpecification(string filter)
            {
                List<Criterion> criterions = new List<Criterion>();
                var criteriaStrings = filter.Split(',');
                foreach (var criteriaString in criteriaStrings)
                {
                    var parts = criteriaString.Split(':');
                    if (parts.Length != 3)
                    {
                        throw new MalformedFilterException();
                    }

                    var criterion = new Criterion();
                    {
                        Field = Char.ToUpper(parts[0][0]) + parts[0][1..],
                        Operator = parts[1].ToUpper(),
                        Value = parts[2]
                    };
                    criterions.Add(criterion);
                }
                return new Specification<T>(criterions);
            }
        }
    }
}
