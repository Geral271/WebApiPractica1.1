using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.Entidades
{
    public class Vuelo
    {
       
        public int Id { get; set; }
        [Required]

        
        public int NumeroVuelo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int PlazaTotal { get; set; }
        public int PlazaTurista { get; set; }

        
    }
}
