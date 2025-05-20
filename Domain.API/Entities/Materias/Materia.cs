using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.Entities
{
    public class Materia
    {
        [Key]
        public int MateriaID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public int Creditos { get; set; } = 3;

        public ICollection<MateriaProfesor> MateriaProfesores { get; set; }
        public ICollection<EstudianteMaterias> EstudianteMaterias { get; set; }
    }
}
