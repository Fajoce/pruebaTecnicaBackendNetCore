using Application.API.Repositories;
using Domain.API.DTOs;
using Domain.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.SpecificationService
{
    public class EstudiantesMismaClasePorIdISpecification: ISpecification<EstudianteMaterias>
    {
        private readonly int _id;

        public EstudiantesMismaClasePorIdISpecification(int id)
        {
            _id = id;
        }

        public Expression<Func<EstudianteMaterias, bool>> ToExpression()
        {
            return em => em.EstudianteID == _id;
        }

    }
}
