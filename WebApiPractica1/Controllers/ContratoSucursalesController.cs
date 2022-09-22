using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPractica1.DTOs;
using WebApiPractica1.Entidades;
using WebApiPractica1.Data;

namespace WebApiPractica1.Controllers
{
    [ApiController]//etiqueta obligatoria (endoint)
    [Route("api/Vuelo")] //ruta del controlador
    public class ContratoSucursalesController : Controller
    {

        private readonly ILogger<ContratoSucursalesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ContratoSucursalesController(ILogger<ContratoSucursalesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // select * from genero

        [HttpGet]

        public async Task<ActionResult<List<ContratoSucursal>>> Get()
        {
            return await context.ContratoSucursales.ToListAsync();

        }

        [HttpGet("(id:int)")]

        public async Task<ActionResult<ContratoSucursalDTO>> Get(int Id)
        {
            var ContratoSucursal = await context.ContratoSucursales.FirstOrDefaultAsync(x => x.Id == Id);

            if (ContratoSucursal == null)
            {
                return NotFound();
            }
            return mapper.Map<ContratoSucursalDTO>(ContratoSucursal);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ContratoSucursalCreacionDTO contratoSucursalCreacionDTO)
        {
            var contratoSucursal = mapper.Map<ContratoSucursalDTO>(contratoSucursalCreacionDTO);
            context.Add(contratoSucursal);
            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(ContratoSucursal contratoSucursal, int id)
        {
            if (contratoSucursal.Id != id)
            {
                return BadRequest("El contrato de sucursal no existe");

                var existe = await context.ContratoSucursales.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

            }

            context.Update(contratoSucursal);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var ContratoSucursal = await context.ContratoSucursales.FirstOrDefaultAsync(x => x.Id == id);
            if (ContratoSucursal == null)
            {
                return NotFound();

            }
            context.Remove(ContratoSucursal);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}