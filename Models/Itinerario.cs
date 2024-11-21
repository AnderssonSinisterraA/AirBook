namespace AirBook.Models
{
    public class Itinerario
    {
        public int IdItinerario { get; set; } // Llave primaria
        public int IdReserva { get; set; }
        public string Detalle { get; set; }
        public Reserva Reserva { get; set; }
    }
}