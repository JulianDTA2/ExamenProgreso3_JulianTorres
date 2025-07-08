using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgreso3_JulianTorres.Models
{
    public class LogEntry
    {
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }

        public string FechaFormateada => Fecha.ToString("dd/MM/yyyy HH:mm");
    }
}
