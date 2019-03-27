using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuarios
    {
        [Key]

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string NombreUser { get; set; }
        public string Clave { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }


        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            NombreUser = string.Empty;
            Clave = string.Empty;
            Tipo = string.Empty;
            Fecha = DateTime.Now;
        }

    }
}