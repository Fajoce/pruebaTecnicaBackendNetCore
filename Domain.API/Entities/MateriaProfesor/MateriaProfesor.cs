using Domain.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.Entities
{
    public class MateriaProfesor
    {
        [Key]
        public int ID { get; set; }
        public int MateriaID { get; set; }
        public Materia Materia { get; set; }

        public int EstudianteID { get; set; }

        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}
