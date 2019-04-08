using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        //Usuarios
        [TestMethod]
        public void GuardarUsuariosTest()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            DateTime feccha = Convert.ToDateTime("2019-04-03");
            Usuarios usuario = new Usuarios()
            {
                Fecha = DateTime.Now,
                Nombre = "Administrador",
                NombreUser = "root",
                Tipo = "Administrador",
                Clave = "123"
            };

            Assert.AreEqual(true, repositorioBase.Guardar(usuario));
        }

        [TestMethod]
        public void ModificarUsuariosTest()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios()
            {
                UsuarioId = 2,
                Fecha = DateTime.Now,
                Nombre = "Administrador",
                NombreUser = "oscar",
                Tipo = "Administrador",
                Clave = "1234"
            };

            var find = repositorioBase.Buscar(usuarios.UsuarioId);

            if (find != null)
            {
                Assert.AreEqual(true, repositorioBase.Modificar(usuarios));

            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EliminarUsuariosTest()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            var find = repositorioBase.Buscar(2);

            if (find != null)
            {
                Assert.AreEqual(true, repositorioBase.Eliminar(find.UsuarioId));

            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BuscarUsuariosTest()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Assert.IsNotNull(repositorioBase.Buscar(2));
        }

        [TestMethod]
        public void GetlistUsuariosTest()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Assert.IsNotNull(repositorioBase.GetList(x=>true));
        }


        //Vehiculos
        [TestMethod]
        public void GuardarVehiculosTest()
        {
            RepositorioBase<Vehiculos> repositorioBase = new RepositorioBase<Vehiculos>();            
            Vehiculos vehiculo = new Vehiculos()
            {
                FechaRegistro = DateTime.Now,
                Tipo = "Sedan",
                Modelo = "M3",
                Marca = "BMW",
                Placa = "A9034",
                Anio = 2019,
                Color = "Rojo",
                PrecioRenta = 500000,
                Descripcion = "New"
            };

            Assert.AreEqual(true, repositorioBase.Guardar(vehiculo));
        }

        [TestMethod]
        public void ModificarVehiculosTest()
        {
            RepositorioBase<Vehiculos> repositorioBase = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculo = new Vehiculos()
            {
                VehiculoId = 3,
                FechaRegistro = DateTime.Now,
                Tipo = "Sedan",
                Modelo = "Cayegen",
                Marca = "Porche",
                Placa = "A9034",
                Anio = 2019,
                Color = "Blanco",
                PrecioRenta = 9000000,
                Descripcion = "New"
            };

            var find = repositorioBase.Buscar(vehiculo.VehiculoId);

            if (find != null)
            {
                Assert.AreEqual(true, repositorioBase.Modificar(vehiculo));

            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EliminarVehiculosTest()
        {
            RepositorioBase<Vehiculos> repositorioBase = new RepositorioBase<Vehiculos>();
            var find = repositorioBase.Buscar(3);

            if (find != null)
            {
                Assert.AreEqual(true, repositorioBase.Eliminar(find.VehiculoId));

            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BuscarVehiculosTest()
        {
            RepositorioBase<Vehiculos> repositorioBase = new RepositorioBase<Vehiculos>();
            Assert.IsNotNull(repositorioBase.Buscar(2));
        }

        [TestMethod]
        public void GetlistVehiculosTest()
        {
            RepositorioBase<Vehiculos> repositorioBase = new RepositorioBase<Vehiculos>();
            Assert.IsNotNull(repositorioBase.GetList(x => true));
        }

        //Clientes
        [TestMethod]
        public void GuardarClientesTest()
        {
            RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes()
            {
                FechaRegistro = DateTime.Now,
                Nombre = "Oscar Slater Jimenez Paula",
                Direccion = "Urb. Almanzar, San Fco. de Macoris",
                Cedula = "04298873458",
                Sexo = "Masculino",
                Telefono = "8092908765",
                FechaNacimiento = Convert.ToDateTime("1996-03-12")
            };

            Assert.AreEqual(true, repositorioBase.Guardar(cliente));
        }

        [TestMethod]
        public void ModificarClientesTest()
        {
            RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes()
            {
                ClienteId =2,
                FechaRegistro = DateTime.Now,
                Nombre = "Oscar Jimenez Paula",
                Direccion = "Urb. Almanzar, San Fco. de Macoris",
                Cedula = "04298873458",
                Sexo = "Masculino",
                Telefono = "8092908765",
                FechaNacimiento = Convert.ToDateTime("1999-03-12")
            };          

            var find = repositorioBase.Buscar(cliente.ClienteId);

            if (find != null)
            {
                Assert.AreEqual(true, repositorioBase.Modificar(cliente));

            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void EliminarClientesTest()
        {
            RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
            var find = repositorioBase.Buscar(2);

            if (find != null)
            {
                Assert.AreEqual(true, repositorioBase.Eliminar(find.ClienteId));

            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BuscarClientesTest()
        {
            RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
            Assert.IsNotNull(repositorioBase.Buscar(2));
        }

        [TestMethod]
        public void GetlistClientesTest()
        {
            RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
            Assert.IsNotNull(repositorioBase.GetList(x => true));
        }

        //Rentas
        [TestMethod]
        public void GuardarRentasTest()
        {
            RepositorioBase<Clientes> repositorioCliente = new RepositorioBase<Clientes>();
            RepositorioBase<Vehiculos> repositorioVehiculo = new RepositorioBase<Vehiculos>();
            RentaRepositorio repositorioRenta = new RentaRepositorio();
            List<RentasDetalles> detalles = new List<RentasDetalles>();
            decimal monto = 0;

            var cliente = repositorioCliente.Buscar(3);
            var vehiculo = repositorioVehiculo.Buscar(1);
                        
            detalles.Add(new RentasDetalles(0, vehiculo.VehiculoId, vehiculo.Anio, vehiculo.Marca, vehiculo.Modelo, vehiculo.PrecioRenta));
            detalles.ForEach(d => monto += d.Precio);

            Rentas renta = new Rentas()
            {
                ClienteId = cliente.ClienteId,
                FechaRegistro = DateTime.Now,
                FechaDevuelta = DateTime.Now.AddMonths(3),
                Detalle = detalles,
                Monto = monto

            };
            Assert.IsNotNull(repositorioRenta.Guardar(renta));
        }

        [TestMethod]
        public void ModificarRentasTest()
        {
            //RepositorioBase<Clientes> repositorioCliente = new RepositorioBase<Clientes>();
            RepositorioBase<Vehiculos> repositorioVehiculo = new RepositorioBase<Vehiculos>();
            RentaRepositorio repositorioRenta = new RentaRepositorio();
            List<RentasDetalles> detalles = new List<RentasDetalles>();
            decimal monto = 0;

            var rentaAnt = repositorioRenta.Buscar(4);
            var cliente = rentaAnt.Clientes;
            var vehiculo = repositorioVehiculo.Buscar(1);

            detalles = rentaAnt.Detalle;

            if(rentaAnt != null)
            {
                detalles.Add(new RentasDetalles(0, vehiculo.VehiculoId, vehiculo.Anio, vehiculo.Marca, vehiculo.Modelo, vehiculo.PrecioRenta));
                detalles.ForEach(d => monto += d.Precio);
            }

         

           /* Rentas renta = new Rentas()
            {
                ClienteId = cliente.ClienteId,
                FechaRegistro = DateTime.Now,
                FechaDevuelta = DateTime.Now.AddMonths(3),
                Detalle = detalles,
                Monto = monto

            };*/
           Assert.IsNotNull(repositorioRenta.Modificar(rentaAnt));
        }

        [TestMethod]
        public void EliminarRentasTest()
        {
            RentaRepositorio repositorioRenta = new RentaRepositorio();
            var find = repositorioRenta.Buscar(5);

            if (find != null)
            {
                Assert.AreEqual(true, repositorioRenta.Eliminar(find.RentaId));

            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BuscarRentasTest()
        {
            RentaRepositorio repositorioRenta = new RentaRepositorio();
            Assert.IsNotNull(repositorioRenta.Buscar(2));
        }

        [TestMethod]
        public void GetlistRentasTest()
        {
            RentaRepositorio repositorioRenta = new RentaRepositorio();
            Assert.IsNotNull(repositorioRenta.GetList(x => true));
        }


    }
}