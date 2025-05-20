using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.DTOs
{
    public class VerNombresEstudiantesDTO
    {
        public string Materia { get; set; }
        public List<string> Companeros { get; set; }
    }
}
