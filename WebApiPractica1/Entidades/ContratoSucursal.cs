using System.ComponentModel.DataAnnotations;

namespace WebApiPractica1.Entidades
{
    public class ContratoSucursal
    {
     
        public int Id { get; set; }
        [Required]


        // relaciones 

        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }
        public int TuristaId { get; set; }
        public Turista Turista { get; set; }

    }
}
