using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ParcialDb Context;

        private DbSet<TEntity> EntitySet
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        public Repositorio()
        {
            Context = new ParcialDb();
        }

        public bool Guardar(TEntity entidad)
        {
            try
            {
                EntitySet.Add(entidad);
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
                return false;
            }
        }

        public bool Modificar(TEntity entidad)
        {
            try
            {
                EntitySet.Attach(entidad);
                Context.Entry<TEntity>(entidad).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public bool Eliminar(TEntity entidad)
        {
            try
            {
                EntitySet.Attach(entidad);
                EntitySet.Remove(entidad);
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
                return false;
            }
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            try
            {
                return EntitySet.FirstOrDefault(criterioBusqueda);
            }
            catch (Exception)
            {

                throw;
                return null;
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            try
            {
                return EntitySet.Where(criterioBusqueda).ToList();
            }
            catch (Exception)
            {

                throw;
                return new List<TEntity>();
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
