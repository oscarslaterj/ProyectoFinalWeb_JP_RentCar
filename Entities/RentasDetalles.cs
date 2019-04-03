using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class RentasDetalles
    {
        [Key]
        public int DetalleId { get; set; }        
        public int VehiculoId { get; set; }
        public int RentaId { get; set; }
        public int Anio { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public decimal Precio { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }

        public RentasDetalles()
        {
            DetalleId = 0;
            //ClienteId = 0;
            VehiculoId = 0;
            RentaId = 0;
            Anio = 0;
            Marca = string.Empty;
            Modelo = string.Empty;
            Precio = 0;
        }

        public RentasDetalles(int idRenta, int idVehiculo,  int anio, string marca, string modelo, decimal precio)
        {
            
            //ClienteId = idcliente;
            VehiculoId = idVehiculo;
            RentaId = idRenta;
            Anio = anio;
            Marca = marca;
            Modelo = modelo;
            Precio = precio;
        }
    }
}