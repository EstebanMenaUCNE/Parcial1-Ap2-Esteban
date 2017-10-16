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
    public class CategoriaBLL
    {
        public static bool Guardar(Categoria categoria)
        {
            using (var repositorio = new Repositorio<Categoria>())
            {
                if (repositorio.Buscar(C => C.CategoriaId == categoria.CategoriaId) == null)
                {
                    return repositorio.Guardar(categoria);
                }
                else
                {
                    //return repositorio.Modificar(presupuesto);
                    using (var context = new ParcialDb())
                    {
                        context.Categorias.Attach(categoria);
                        context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                        return context.SaveChanges() > 0;
                    }
                }
            }
        }

        public static Categoria Buscar(Expression<Func<Categoria, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<Categoria>())
            {
                return repositorio.Buscar(criterioBusqueda);
            }
        }

        public static bool Eliminar(Categoria categoria)
        {
            using (var repositorioCategorias = new Repositorio<Categoria>())
            {
                using (var repositorioPresupuestos = new Repositorio<Presupuesto>())
                {
                    foreach (var presupuesto in repositorioPresupuestos.GetList(P => P.CategoriaId == categoria.CategoriaId))
                    {
                        repositorioPresupuestos.Eliminar(presupuesto);
                    }
                }
                return repositorioCategorias.Eliminar(categoria);
            }
        }

        public static List<Categoria> GetList(Expression<Func<Categoria, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<Categoria>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }
    }
}
