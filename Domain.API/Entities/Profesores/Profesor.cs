using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.Entities
{
    public class Profesor
    {
        [Key]
        public int ProfesorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public ICollection<MateriaProfesor> MateriaProfesores { get; set; }
    }
}
