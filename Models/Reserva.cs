namespace AirBook.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; } // Clave primaria
        public int IdPasajero { get; set; }
        public int IdVuelo { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }
        public Pasajero? Pasajero { get; set; }
        public Vuelo? Vuelo { get; set; }
    }
}
