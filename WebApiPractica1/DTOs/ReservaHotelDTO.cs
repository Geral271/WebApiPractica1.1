using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.DTOs
{
    public class ReservaHotelDTO
    {
        public int Id { get; set; }
        [Required]

        public int CodigoTurista { get; set; }
        public int CodigoHotel { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaPartida { get; set; }
        public int Regimen { get; set; }
    }
}
