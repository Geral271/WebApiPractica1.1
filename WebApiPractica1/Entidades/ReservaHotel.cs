using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.Entidades
{
    public class ReservaHotel
    {

        public int Id { get; set; }
        [Required]

        public int Regimen { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaPartida { get; set; }
        
        // relaciones 

        public int TuristaId { get; set; }
        public Turista turista { get; set; }
        public int HotelId { get; set; }
        public Hotel hotel { get; set; }
        
          
    }
}

