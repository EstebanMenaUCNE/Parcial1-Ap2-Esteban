using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PresupuestoBLL
    {
        public static bool Guardar(Presupuesto presupuesto)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                if (repositorio.Buscar(P => P.PresupuestoId == presupuesto.PresupuestoId) == null)
                {
                    return repositorio.Guardar(presupuesto);
                }
                else
                {
                    return repositorio.Modificar(presupuesto);
                }
            }
        }

        public static Presupuesto Buscar(Expression<Func<Presupuesto, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                return repositorio.Buscar(criterioBusqueda);
            }
        }

        public static bool Eliminar(Presupuesto presupuesto)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                return repositorio.Eliminar(presupuesto);
            }
        }

        public static List<Presupuesto> GetList(Expression<Func<Presupuesto, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<Presupuesto>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }
    }
}
