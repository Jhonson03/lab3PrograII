using lab3.Data;
using lab3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DAO
{
    public class CruFacultades
    {
        FacultadContext db = new FacultadContext();

        public facultades Facultadindivi(int Id)
        {
            var buscar = db.facultades.FirstOrDefault(x => x.id == Id);

            return buscar;
        }

        public void CreateFacultad(facultades fa)
        {
            facultades facultad = new facultades();

            facultad.id = fa.id;
            facultad.nombre = fa.nombre;
            facultad.coordinador = fa.coordinador;
            facultad.asignaturas = fa.asignaturas;
            facultad.docentes = fa.docentes;

            db.Add(facultad);
            db.SaveChanges();
        }

        public void UpdateFacul(facultades fa, int Lector)
        {
            var buscar = Facultadindivi(fa.id);

            if (buscar == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                if(Lector == 1)
                {
                    buscar.nombre = fa.nombre;
                }
            }
        }

        public List<facultades> ViewFacultades()
        {
            return db.facultades.ToList();  
        }
    }
    
}
