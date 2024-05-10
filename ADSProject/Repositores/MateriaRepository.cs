using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class MateriaRepository : IMateria
    {
        /*private List<Materia> lstMateria = new List<Materia>
        {
            new Materia{IdMateria = 1, NombreMateria = "Desarrollo",

            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;

        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int AgregarMateria(Materia materia)
        {
            try
            {
                /*if (lstMateria.Count > 0)
                {
                    materia.IdMateria = lstMateria.Last().IdMateria + 1;
                }
                lstMateria.Add(materia);
                return materia.IdMateria;*/
                applicationDbContext.Materias.Add(materia);
                applicationDbContext.SaveChanges();

                return materia.IdMateria;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                /*int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);
                lstMateria[indice] = materia;
                return idMateria;*/
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                applicationDbContext.Entry(item).CurrentValues.SetValues(materia);
                applicationDbContext.SaveChanges();
                return idMateria;


            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public bool EliminarMateria(int idMateria)
        {
            try
            {
                /*int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);
                lstMateria.RemoveAt(indice);
                return true;*/
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                applicationDbContext.Materias.Remove(item);
                applicationDbContext.SaveChanges();

                return true;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Materia ObtenermateriaPorID(int idMateria)
        {
            try
            {
                /*Materia materia = lstMateria.FirstOrDefault(tmp => tmp.IdMateria == idMateria);
                return materia;*/
                var materia = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                return materia;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Materia> ObtenerTodosLasMaterias()
        {
            try
            {
                return applicationDbContext.Materias.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
