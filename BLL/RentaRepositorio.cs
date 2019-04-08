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
        public RentaRepositorio():base()
        {
            
        }

        public override bool Guardar(Rentas renta)
        {
            bool paso = false;

            try
            {
                Clientes cliente = new Clientes(
                    renta.Clientes.ClienteId,
                    renta.Clientes.Nombre,
                    renta.Clientes.Cedula,
                    renta.Clientes.Direccion,
                    renta.Clientes.Telefono,
                    DateTime.Parse(renta.Clientes.FechaNacimiento.ToString("yyyy-MM-dd")),
                    renta.Clientes.VehiculosRentados                    
                    );
                cliente.FechaRegistro = DateTime.Parse(renta.Clientes.FechaRegistro.ToString("yyyy-MM-dd"));
                renta.Clientes = null;
                var cantidad = renta.Detalle.Count;
                cliente.VehiculosRentados += cantidad;

                _contexto.Renta.Add(renta);
               _contexto.Clientes.Attach(cliente);
               _contexto.Entry(cliente).State = EntityState.Modified;

                //var cliente = _contexto.Clientes.Find(renta.ClienteId);
                //cliente.VehiculosRentados += cantidad;
                _contexto.SaveChanges();
                paso = true;
                
            }
            catch (Exception)
            {
                throw;
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
          
            return paso;
        }



        public override bool Modificar(Rentas renta)
        {
            bool paso = false;

            try
            {
               
                var rentaAnt = _contexto.Renta.Where(x => x.RentaId == renta.RentaId).AsNoTracking().FirstOrDefault();
                //var detalleAnt = _contexto.Rentadetalle.Where(r => r.RentaId == rentaAnt.RentaId).AsNoTracking().ToList();
                var cantidad = rentaAnt.Detalle.Count;

                foreach(var item in rentaAnt.Detalle)
                {
                    _contexto.Entry(item).State = (renta.Detalle.Contains(item)) ? EntityState.Modified : EntityState.Deleted;                    
                }

                foreach (var item in renta.Detalle)
                {
                    _contexto.Entry(item).State = (rentaAnt.Detalle.Contains(item)) ? EntityState.Modified : EntityState.Added;                    
                }

                renta.Clientes.VehiculosRentados += cantidad;
                _contexto.Entry(rentaAnt).State = EntityState.Modified;
                _contexto.Entry(renta).State = EntityState.Modified;
                _contexto.SaveChanges();               
                paso = true;               
            }
            catch (Exception)
            {
                throw;
            }
          
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            try
            {              
                var renta = _contexto.Renta.Find(id);
                var cantidad = renta.Detalle.Count;

                //_contexto.Rentadetalle.RemoveRange(_contexto.Rentadetalle.Where(x => x.RentaId == Ant.RentaId));
                //_contexto.Entry(Ant).State = System.Data.Entity.EntityState.Deleted;
                var cliente = _contexto.Clientes.Find(renta.ClienteId);
                cliente.VehiculosRentados -= cantidad;
                _contexto.Entry(cliente).State = EntityState.Modified;
                _contexto.Renta.Remove(renta);
                _contexto.SaveChanges();
                
                paso = true;         
            }
            catch (Exception)
            {
                throw;
            } 
            
            return paso;
        }

        public override Rentas Buscar(int id)
        {
            Rentas renta = new Rentas();
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
           


            return renta;
        }

        public override List<Rentas> GetList(Expression<Func<Rentas, bool>> expression)
        {
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
           

            return lista;
        }
    }
}
