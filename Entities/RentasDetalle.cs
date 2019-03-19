using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class RentasDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int RentaId { get; set; }
        public String Año { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public decimal Precio { get; set; }

        public RentasDetalle()
        {
            DetalleId = 0;
            ClienteId = 0;
            VehiculoId = 0;
            RentaId = 0;
            Año = string.Empty;
            Marca = string.Empty;
            Modelo = string.Empty;
            Precio = 0;
        }

        public RentasDetalle(int idDetalle, int idcliente, int idVehiculo, int idRenta, string año, string marca, string modelo, decimal precio)
        {
            DetalleId = idDetalle;
            ClienteId = idcliente;
            VehiculoId = idVehiculo;
            RentaId = idRenta;
            Año = año;
            Marca = marca;
            Modelo = modelo;
            Precio = precio;
        }
    }
}