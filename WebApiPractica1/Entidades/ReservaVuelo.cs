using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.Entidades
{
    public class ReservaVuelo
    {
        
        public int Id { get; set; }
        [Required]

        public string Clase { get; set; }

        //relaciones
        public int VueloId { get; set; }
        public Vuelo vuelo { get; set; }
        public int TuristaId { get; set; }
        public Turista turista { get; set; }

    }
}
