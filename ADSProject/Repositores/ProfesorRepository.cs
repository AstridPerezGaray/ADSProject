using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;
using Microsoft.AspNetCore.Http.Features;

namespace ADSProject.Repositores
{
    
    public class ProfesorRepository : IProfesor
    {
        /*/private List<Profesor> lstprofesor = new List<Profesor>
        {
            new Profesor{IdProfesor = 1, NombresProfesor = "JUAN CARLOS",
            ApellidosProfesor= "PEREZ SOSA", Email = "JCPS@gmail.com",

            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                /*if (lstprofesor.Count > 0)
                {
                    profesor.IdProfesor = lstprofesor.Last().IdProfesor + 1;
                }
                lstprofesor.Add(profesor);
                return profesor.IdProfesor;*/
                applicationDbContext.Profesores.Add(profesor);
                applicationDbContext.SaveChanges();

                return profesor.IdProfesor;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                /*int indice = lstprofesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstprofesor[indice] = profesor;
                return idProfesor;*/
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Entry(item).CurrentValues.SetValues(profesor);
                applicationDbContext.SaveChanges();
                return idProfesor;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                /*int indice = lstprofesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstprofesor.RemoveAt(indice);
                return true;*/
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Profesores.Remove(item);
                applicationDbContext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Profesor ObtenerprofesorPorID(int idprofesor)
        {

            try
            {
                /*Profesor profesor = lstprofesor.FirstOrDefault(tmp => tmp.IdProfesor == idprofesor);
                return profesor;*/
                var profesor = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idprofesor);
                return profesor;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                return applicationDbContext.Profesores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
