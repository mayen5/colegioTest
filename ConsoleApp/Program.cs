// See https://aka.ms/new-console-template for more information
using AccesoDatos.Operations;

Console.WriteLine("____________________");

AlumnoDAO opAlumno = new AlumnoDAO();

//opAlumno.insertAlumno("Carmelo", "Mayen", "Masculino", new DateTime(2012,05,30));
//opAlumno.updateAlumno(12, "Stuart", "Monte", "Masculino", new DateTime(2012,05,31));
opAlumno.deleteAlumno(12);

var alumnos = opAlumno.selectAll();


foreach (var alumno in alumnos)
{
    Console.WriteLine(alumno.Nombre + " " + alumno.Apellidos);

}
    

Console.WriteLine("____________________");

var alumno1 = opAlumno.selectAlumno(5);
if (alumno1 != null)
{
    Console.WriteLine("El alumno con id = 5 es: " + alumno1.Nombre + " " + alumno1.Apellidos);

}
else
{
    Console.WriteLine("El alumno con id = 5 no existe!");

}

Console.WriteLine("____________________");