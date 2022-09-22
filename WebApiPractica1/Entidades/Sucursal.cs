using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.Entidades
{
    public class Sucursal
    {
        public int Id { get; set; }
        [Required]


        public int CodigoSucursal { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }
}
