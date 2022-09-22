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
    public class SucursalesController : Controller
    {

        private readonly ILogger<SucursalesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SucursalesController(ILogger<SucursalesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // select * from genero

        [HttpGet]

        public async Task<ActionResult<List<Sucursal>>> Get()
        {
            return await context.Sucursales.ToListAsync();

        }

        [HttpGet("(id:int)")]

        public async Task<ActionResult<SucursalDTO>> Get(int Id)
        {
            var Sucursal = await context.Sucursales.FirstOrDefaultAsync(x => x.Id == Id);

            if (Sucursal == null)
            {
                return NotFound();
            }
            return mapper.Map<SucursalDTO>(Sucursal);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] SucursalCreacionDTO sucursalCreacionDTO)
        {
            var sucursal = mapper.Map<VueloDTO>(sucursalCreacionDTO);
            context.Add(sucursal);
            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Sucursal sucursal, int id)
        {
            if (sucursal.Id != id)
            {
                return BadRequest("Esta sucursal no existe");

                var existe = await context.Sucursales.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

            }

            context.Update(sucursal);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var Sucursal = await context.Sucursales.FirstOrDefaultAsync(x => x.Id == id);
            if (Sucursal == null)
            {
                return NotFound();

            }
            context.Remove(Sucursal);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}