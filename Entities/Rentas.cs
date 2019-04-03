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
    public class Rentas
    {
        [Key]
        public int RentaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaDevuelta { get; set; }
        public int ClienteId { get; set; }

        public virtual List<RentasDetalles> Detalle { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }


        public Rentas()
        {
            RentaId = 0;
            FechaRegistro = DateTime.Now;
            FechaDevuelta = DateTime.Now;
            ClienteId = 0;
            Detalle = new List<RentasDetalles>();
        }

        public void AgregarDetalle(int idRenta, int idVehiculo, int anio, string marca, string modelo, decimal precio)
        {
            this.Detalle.Add(new RentasDetalles(idRenta, idVehiculo, anio, marca, modelo, precio));
        }

    }
}