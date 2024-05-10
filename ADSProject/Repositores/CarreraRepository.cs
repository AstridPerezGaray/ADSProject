using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositores
{
    public class CarreraRepository : IECarrera
    {
        /*private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera{IdCarrera = 1, CodigoCarrera = "01",
            NombreCarrera= "ANALISIS DE SISTEMAS"
            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;

        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                /*if (lstCarrera.Count > 0)
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera + 1;
                }
                lstCarrera.Add(carrera);
                return carrera.IdCarrera;*/
                applicationDbContext.Carreras.Add(carrera);
                applicationDbContext.SaveChanges();
                return carrera.IdCarrera;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                /*int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                lstCarrera[indice] = carrera;
                return idCarrera;*/

                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                if (item != null)
                {
                    applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                    applicationDbContext.SaveChanges();
                    return idCarrera;
                }
                return -1; // Indicar que no se encontró la carrera
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                /*int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                lstCarrera.RemoveAt(indice);
                return true;*/
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                if (item != null)
                {
                    applicationDbContext.Carreras.Remove(item);
                    applicationDbContext.SaveChanges();
                    return true;
                }
                return false; // Indicar que no se encontró la carrera
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Carrera ObtenercarrerasPorID(int idcarreras)
        {
            try
            {
                /*Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == idcarreras);
                return carrera;*/
                var carrera = applicationDbContext.Carreras.FirstOrDefault(c => c.IdCarrera == idcarreras);
                return carrera;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Carrera> ObtenerTodosLasCarreras()
        {
            try
            {
                return applicationDbContext.Carreras.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
