using Domain.API.DTOs;
using Domain.API.DTOs.MateriasProfesor;
using Domain.API.Entities;
using Domain.API.Repositorios.MateriaProfesor;
using InfraEstructura.API.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.Services
{
    public class MateriaProfesorSerrvice : IMateriasProfesorRepository
    {
        private readonly ColegioDbContext _context;

        public MateriaProfesorSerrvice(ColegioDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistoDeClases(MateriasProfesorDTO entity)
        {
            // Validar que el estudiante NO tenga ya una materia con el mismo profesor
            var yaTieneClaseConProfesor = await _context.MateriasProfesores
                .AnyAsync(mp => mp.EstudianteID == entity.EstudianteID && mp.ProfesorID == entity.ProfesorID);

            if (yaTieneClaseConProfesor)
            {
                throw new InvalidOperationException("El estudiante ya tiene una clase con este profesor.");
            }
            var classRecord = new MateriaProfesor
            {
                MateriaID = entity.MateriaID,
                ProfesorID = entity.ProfesorID,
                EstudianteID = entity.EstudianteID
            };
            await _context.MateriasProfesores.AddAsync(classRecord);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<SelectEstudiantesDTO>> VerTodosEstudiantes()
        {
            var students = await (from e in _context.Estudiantes
                                  select new SelectEstudiantesDTO
                                  {
                                      EstudianteID = e.EstudianteID,
                                      Nombre = e.Nombre
                                  }).ToListAsync();
            return students;
        }

        public async Task<List<SelectMateriasDTO>> VerTodosMaterias()
        {
            var subjects = await (from m in _context.Materias
                                  select new SelectMateriasDTO
                                  {
                                      MateriaID = m.MateriaID,
                                      Nombre = m.Nombre
                                  }).ToListAsync();
            return subjects;
                

        }

        public async Task<List<SelectProfesoresDTO>> VerTodosProfesores()
        {
            var teachers = await (from p in _context.Profesores
                                  select new SelectProfesoresDTO
                                  {
                                      ProfesorID = p.ProfesorID,
                                      Nombre = p.Nombre
                                  }).ToListAsync();
            return teachers;
        }

   

        public async Task<List<VerRegistrosDTO>> VerTodosRegistros()
        {
            var records = await (from mp in _context.MateriasProfesores
                                 join m in _context.Materias
                                 on mp.MateriaID equals m.MateriaID
                                 join p in _context.Profesores
                                 on mp.ProfesorID equals p.ProfesorID
                                 join e in _context.Estudiantes
                                 on mp.EstudianteID equals e.EstudianteID

                                 select new VerRegistrosDTO
                                 {
                                     EstudianteID = e.EstudianteID,
                                     EstudianteNombre = e.Nombre,
                                     ProfesorID = p.ProfesorID,
                                     ProfesorNombre = p.Nombre,
                                     MateriaID = m.MateriaID,
                                     MateriaNombre = m.Nombre
                                 }).ToListAsync();
            return records;
        }

    
    }
}
