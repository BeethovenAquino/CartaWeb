using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidadades
{
    public class Cartas
    {
        [Key]
        public int CartaID { get; set; }
        public DateTime Fecha { get; set; }
        public int DestinarioID { get; set; }
        public string Cuerpo { get; set; }

        public Cartas(int cartaID, DateTime fecha, int destinarioID, string cuerpo)
        {
            CartaID = cartaID;
            Fecha = fecha;
            DestinarioID = destinarioID;
            Cuerpo = cuerpo;
        }

        public Cartas()
        {
            CartaID = 0;
            Fecha = DateTime.Now;
            DestinarioID = 0;
            Cuerpo = string.Empty;
        }
    }
}
