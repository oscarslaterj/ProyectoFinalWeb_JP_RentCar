using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Renta
    {
        [Key]
        public int RentaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaDevuelta { get; set; }

        public virtual List<RentasDetalle> Detalle { get; set; }

        public Renta()
        {
            RentaId = 0;
            FechaRegistro = DateTime.Now;
            FechaDevuelta = DateTime.Now;

            Detalle = new List<RentasDetalle>();
        }


    }
}