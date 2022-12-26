using System.Collections.Generic;
using System.Linq;
using WebApi.Evaluacion.Model;

namespace WebApi.Evaluacion.Persistencia
{
    public class Datos
    {
        public static List<Dato> listaD = new List<Dato>()
        {
            //ejemplo base
            new Dato() {Id = 1, Empresa = "Gloria"},
            new Dato() {Id = 2, Empresa = "Odebrech"},
            new Dato() {Id = 3, Empresa = "Navarrete"}
            // ...
        };

        public IEnumerable<Dato> ObtenerDatos()
        {
            return listaD;
        }

        public Dato ObtenerDato(int id)
        {
            var dato = listaD.Where(dat => dat.Id == id);

            return dato.FirstOrDefault();
        }

        public void Agregar(Dato newDato)
        {
            listaD.Add(newDato);
        }

        public bool Eliminar(int id)
        {
            try
            {
                int index = listaD.FindIndex(dat => dat.Id == id);
                listaD.RemoveAt(index);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public void Actualizar(Dato updDato)
        {
            var obj = listaD.FirstOrDefault(dat => dat.Id == updDato.Id);

            if(obj != null) obj.Empresa = updDato.Empresa;
        }
    }
}
