using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talma.Core.Entities;
using Talma.Core.Interfaces;
using Talma.Core.Models;

namespace Talma.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ModelContext context;

        public StudentRepository(ModelContext _context)
        {
            context = _context;
        }

        public Response ListStudents()
        {
            Response response = new Response();
            var students = new List<Estudiante>();
            students = context.Estudiantes.ToList();

            if (students.Count != 0)
            {
                response.code = 200;
                response.msg = "Ok";
                response.data = students;
            }
            else
            {
                response.code = 200;
                response.msg = "No existen registros en la BD";
            }


            return response;
        }

        public Response GetStudent(StudentByIdRequest obj)
        {
            Response response = new Response();
            try
            {
                var students = new List<Estudiante>();
                var student = new Estudiante();
                student = context.Estudiantes.Where(x => x.Id == obj.Id).FirstOrDefault();

                if (student != null)
                {
                    students.Add(student);
                    response.code = 200;
                    response.msg = "Ok";
                    response.data = students;
                }
                else
                {
                    response.code = 400;
                    response.msg = "No se encontró ID en la BD";
                }

                return response;
            }
            catch (Exception ex)
            {

                response.code = 500;
                response.msg = ex.Message;

                return response;
            }
            
        }

        public Response RegStudent(StudentCreateRequest obj)
        {
            Response response = new Response();
            try
            {
                var student = new Estudiante();
                student.Nombres = obj.Nombres;
                student.Apellidos = obj.Apellidos;
                student.NombreCompleto = obj.Nombres + ' ' + obj.Apellidos;
                student.NumDocumentoIdentidad = obj.NumDocumentoIdentidad;
                student.CorreoElectronico = obj.CorreoElectronico;
                student.FechaNacimiento = obj.FechaNacimiento;
                student.Edad = CalcularEdad(obj.FechaNacimiento);
                student.FechaHoraRegistro = DateTime.Now;
                context.Estudiantes.Add(student);
                context.SaveChanges();

                response.code = 200;
                response.msg = "Se registró correctamente";

                return response;
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;

                return response;
            }
        }

        public Response UpdStudent(StudentUpdateRequest obj)
        {
            Response response = new Response();
            try
            {

                var student = context.Estudiantes.Where(x => x.Id == obj.Id).FirstOrDefault();
                if (student != null)
                {
                    student.Nombres = obj.Nombres;
                    student.Apellidos = obj.Apellidos;
                    student.NombreCompleto = obj.Nombres + ' ' + obj.Apellidos;
                    student.NumDocumentoIdentidad = obj.NumDocumentoIdentidad;
                    student.CorreoElectronico = obj.CorreoElectronico;
                    student.FechaNacimiento = obj.FechaNacimiento;
                    student.Edad = CalcularEdad(obj.FechaNacimiento);
                    student.FechaHoraModificacion = DateTime.Now;
                    context.SaveChanges();

                    response.code = 200;
                    response.msg = "Se modificó correctamente";
                }
                else
                {
                    response.code = 400;
                    response.msg = "No se encontró ID en la BD";
                }


                return response;
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;

                return response;
            }

        }

        public Response DelStudent(StudentByIdRequest obj)
        {
            Response response = new Response();
            try
            {

                var student = context.Estudiantes.Where(x => x.Id == obj.Id).FirstOrDefault();
                if (student != null)
                {
                    context.Remove(student);
                    context.SaveChanges();


                    response.code = 200;
                    response.msg = "Se eliminó correctamente";
                }
                else
                {
                    response.code = 400;
                    response.msg = "No se encontró ID en la BD";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;

                return response;
            }
        }


        static int CalcularEdad(DateTime fechaNacimiento)
        {
            // Fecha actual
            DateTime fechaActual = DateTime.Today;

            // Calculamos la edad
            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Si no ha cumplido años este año, restamos uno a la edad
            if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }
    }
}
