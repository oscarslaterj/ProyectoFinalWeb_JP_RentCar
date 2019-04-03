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
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarClientesTest()
        {
            RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
            DateTime feccha = Convert.ToDateTime("2019-04-03");
          var cliente =  new Clientes()
            {
                ClienteId = 0,
                FechaNacimiento = feccha,
                FechaRegistro = DateTime.Now,
                Cedula = "05609090999",
                Direccion = "SFM",
                Nombre ="Juan",
                Sexo ="Masculino",
                Telefono = "8292082124"

            };


            Assert.AreEqual(true,repositorioBase.Guardar(cliente));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}