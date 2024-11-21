using System.ComponentModel.DataAnnotations;

namespace AirBook.Models
{
    public class Vuelo
    {
        public int IdVuelo { get; set; } // Clave primaria
        public string NumeroVuelo { get; set; }
        public int AerolineaId { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraLlegada { get; set; }
        public decimal Precio { get; set; }
        public Aerolinea? Aerolinea { get; set; }
    }
}