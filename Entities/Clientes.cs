using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Clientes
    {
        [Key]

        public int ClienteId { get; set; }
        public String Nombre { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int VehiculosRentados { get; set; }


        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            FechaNacimiento = DateTime.Now;
            VehiculosRentados = 0;
        }

    }
}