using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RentaBLL
    {
        public static bool Guardar(Rentas renta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Renta.Add(renta) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Rentas renta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Anterior = db.Renta.Find(renta.RentaId);
                db.Entry(renta).State = EntityState.Modified;
                foreach (var item in Anterior.Detalle)
                {
                    /*if (!renta.Vehiculos.Exists(d => d.VehiculoID== item.VehiculoID))
                        db.Entry(item).State = EntityState.Deleted;*/
                    if (item.VehiculoId == 0)
                        GuardarDetalle(item);
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                        paso = db.SaveChanges() > 0;
                    }
                }

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }

            return paso;
        }

        private static bool GuardarDetalle(RentasDetalles Detalle)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Rentadetalle.Add(Detalle) != null)
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

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Eliminar = db.Renta.Find(Id);
                db.Entry(Eliminar).State = System.Data.Entity.EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Rentas Buscar(int Id)
        {
            Contexto db = new Contexto();
            Rentas renta = new Rentas();
            try
            {
                renta = db.Renta.Find(Id);
                renta.Detalle.Count();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return renta;
        }


        public static List<Rentas> GetList(Expression<Func<Rentas, bool>> renta)
        {
            List<Rentas> Lista = new List<Rentas>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Renta.Where(renta).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

    }
}