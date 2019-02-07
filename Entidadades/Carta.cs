using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidadades
{
    public class Carta
    {
        [Key]
        public int CartaID { get; set; }
        public DateTime Fecha { get; set; }
        public int DestinarioID { get; set; }
        public string Cuerpo { get; set; }
        public int CantidadCartas { get; set; }

        public Carta(int cartaID, DateTime fecha, int destinarioID, string cuerpo, int cantidadCartas)
        {
            CartaID = cartaID;
            Fecha = fecha;
            DestinarioID = destinarioID;
            Cuerpo = cuerpo;
            CantidadCartas = cantidadCartas;
        }

        public Carta()
        {
            CartaID = 0;
            Fecha = DateTime.Now;
            DestinarioID = 0;
            Cuerpo = string.Empty;
            CantidadCartas = 0;
        }
    }
}
