using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.DTOs.MateriasProfesor
{
    public class VerRegistrosDTO
    {
        public int EstudianteID { get; set; }
        public int MateriaID { get; set; }
        public int ProfesorID { get; set; }
        public string EstudianteNombre { get; set; }
        public string MateriaNombre { get; set; }
        public string ProfesorNombre { get; set; }
    }
}
