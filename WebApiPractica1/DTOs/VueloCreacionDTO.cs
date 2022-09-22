using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.DTOs
{
    public class VueloCreacionDTO
    {

        public int NumeroVuelo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int PlazaTotal { get; set; }
        public int PlazaTurista { get; set; }
    }
}
