using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.DTOs
{
    public class ReservaVueloDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int CodigoSucursal { get; set; }
        public int NumeroVuelo { get; set; }
        public string Clase { get; set; }
    }
}
