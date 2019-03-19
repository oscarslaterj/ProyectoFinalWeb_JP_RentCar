using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Clientes.Add(clientes) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool Modificar(Clientes clientes)
        {
            Contexto db = new Contexto();
            bool paso = true;
            try
            {
                db.Entry(clientes).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = true;
            try
            {
                Clientes clientes = db.Clientes.Find(id);
                db.Clientes.Remove(clientes);
                if (db.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static Clientes Buscar(int id)
        {
            Contexto db = new Contexto();
            Clientes clientes = new Clientes();
            try
            {
                clientes = db.Clientes.Find(id);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return clientes;
        }
        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Clientes> clientes = new List<Clientes>();
            try
            {
                clientes = db.Clientes.Where(expression).ToList();
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return clientes;
        }
    }
}

