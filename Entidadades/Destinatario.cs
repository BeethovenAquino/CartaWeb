using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidadades
{
    public class Destinatario
    {
        [Key]
        public int DestinatarioID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
    }
}
