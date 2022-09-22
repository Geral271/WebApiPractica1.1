using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.Entidades
{
    public class Hotel
    {
       
        public int Id { get; set; }
        [Required]

        public int CodigoHotel { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int Telefono { get; set; }
        public int NumPlazas { get; set; }
}
}
