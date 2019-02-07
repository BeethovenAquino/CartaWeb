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
        public int CantCartas { get; set; }

        public Destinatario(int destinatarioID, DateTime fecha, string nombre, int cantCartas)
        {
            DestinatarioID = destinatarioID;
            Fecha = fecha;
            Nombre = nombre;
            CantCartas = cantCartas;
        }

        public Destinatario()
        {
            DestinatarioID = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            CantCartas = 0;
        }
    }


}
