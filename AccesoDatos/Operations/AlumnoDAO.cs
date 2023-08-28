using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class AlumnoDAO
    {
        public ColegioContext contexto = new ColegioContext();

        public List<Alumno> selectAll()
        {
            var alumnos = contexto.Alumnos.ToList();
            return alumnos;
        }

        public Alumno selectAlumno(int id)
        {
            var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();

            return alumno;
        }

        public bool insertAlumno(string nombre, string apellidos, string genero, DateTime fechaNacimiento)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.Nombre = nombre;
                alumno.Apellidos = apellidos;
                alumno.Genero = genero;
                alumno.FechaNacimiento = fechaNacimiento;

                contexto.Alumnos.Add(alumno);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception e)
            { 
                return false;   
            }
        }

        public bool updateAlumno(int id, string nombre, string apellidos, string genero, DateTime fechaNacimiento)
        {
            try
            {

                var alumno = selectAlumno(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    alumno.Nombre = nombre;
                    alumno.Apellidos = apellidos;
                    alumno.Genero = genero;
                    alumno.FechaNacimiento = fechaNacimiento;

                    contexto.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool deleteAlumno(int id)
        {

            try
            {
                var alumno = selectAlumno(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
