﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.DTOs.Estudiantes
{
    public class CrearEstudianteDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
