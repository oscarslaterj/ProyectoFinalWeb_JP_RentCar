using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto _contexto;

        public RepositorioBase()
        {
            _contexto = new Contexto();
        }

        public virtual T Buscar(int id)
        {
            T entity;
            _contexto = new Contexto();
            try
            {
                entity = _contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return entity;
        }

        public virtual bool Eliminar(int id)
        {
            _contexto = new Contexto();
            bool paso = false;
            try
            {
                T entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

                _contexto.Dispose();
            }
            catch (Exception)
            { throw; }
            return paso;
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            _contexto = new Contexto();
            List<T> Lista = new List<T>();
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            _contexto = new Contexto();
            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                {
                    _contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            _contexto = new Contexto();
            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}