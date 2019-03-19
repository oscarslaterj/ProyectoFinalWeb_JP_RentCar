using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Mantenimiento
    {
        public string Concepto { get; set; }
        public string Taller { get; set; }
        public DateTime Fecha { get; set; }
    }
}