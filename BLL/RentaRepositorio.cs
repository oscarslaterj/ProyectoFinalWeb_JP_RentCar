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
    public class RentaRepositorio : RepositorioBase<Rentas>
    {
        public override bool Guardar(Rentas renta)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();

            try
            {
                var cantidad = renta.Detalle.Count;
                if (_contexto.Renta.Add(renta) != null)
                {
                    _contexto.Clientes.Find(renta.ClienteId).VehiculosRentados += cantidad;
                    _contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return paso;
        }

        public bool GuardarDetalle(RentasDetalles detalle)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
                if (_contexto.Rentadetalle.Add(detalle) != null)
                {
                    _contexto.SaveChanges();

                    paso = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return paso;
        }



        public override bool Modificar(Rentas renta)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();

            try
            {

                var rentaAnt = _contexto.Renta.Find(renta.RentaId);
                var detalleAnt = _contexto.Rentadetalle.Where(r => r.RentaId == rentaAnt.RentaId).AsNoTracking().ToList();
                var cantidad = rentaAnt.Detalle.Count;

                _contexto.Entry(rentaAnt).State = EntityState.Deleted;
                _contexto.Entry(renta).State = EntityState.Modified;
                _contexto.Clientes.Find(rentaAnt.ClienteId).VehiculosRentados += cantidad;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
               
                var Ant = _contexto.Renta.Find(id);
                var cantidad = Ant.Detalle.Count;
                if (Ant != null)
                {
                    _contexto.Rentadetalle.RemoveRange(_contexto.Rentadetalle.Where(x => x.RentaId == Ant.RentaId));
                    _contexto.Entry(Ant).State = System.Data.Entity.EntityState.Deleted;
                    _contexto.Clientes.Find(Ant.ClienteId).VehiculosRentados -= cantidad;
                    if (_contexto.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                _contexto.Dispose();
            }



            return paso;
        }

        public override Rentas Buscar(int id)
        {
            Rentas renta = new Rentas();
            _contexto = new DAL.Contexto();
            try
            {
                renta = _contexto.Renta.Find(id);

                if (renta != null)
                {
                    renta.Detalle.Count();

                }



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }


            return renta;
        }

        public override List<Rentas> GetList(Expression<Func<Rentas, bool>> expression)
        {
            _contexto = new DAL.Contexto();
            List<Rentas> lista = new List<Rentas>();
            try
            {
                lista = _contexto.Renta.Where(expression).ToList();
                foreach (var item in lista)
                {
                    item.Detalle.Count();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return lista;
        }
    }
}
