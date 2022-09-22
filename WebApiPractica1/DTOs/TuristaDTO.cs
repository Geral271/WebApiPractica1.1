using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.DTOs
{
    public class TuristaDTO
    {
        public int Id { get; set; }
        [Required]

        public int CodigoTurista { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }
}
