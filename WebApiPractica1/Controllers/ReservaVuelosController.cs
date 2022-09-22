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
    public class ReservaVuelosController : Controller
    {

        private readonly ILogger<ReservaVuelosController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReservaVuelosController(ILogger<ReservaVuelosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // select * from genero

        [HttpGet]

        public async Task<ActionResult<List<ReservaVuelo>>> Get()
        {
            return await context.ReservaVuelos.ToListAsync();

        }

        [HttpGet("(id:int)")]

        public async Task<ActionResult<ReservaVueloDTO>> Get(int Id)
        {
            var ReservaVuelo = await context.ReservaVuelos.FirstOrDefaultAsync(x => x.Id == Id);

            if (ReservaVuelo == null)
            {
                return NotFound();
            }
            return mapper.Map<ReservaVueloDTO>(ReservaVuelo);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ReservaVueloCreacionDTO reservaVueloCreacionDTO)
        {
            var reservaVuelo = mapper.Map<VueloDTO>(reservaVueloCreacionDTO);
            context.Add(reservaVuelo);
            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(ReservaVuelo reservaVuelo, int id)
        {
            if (reservaVuelo.Id != id)
            {
                return BadRequest("La reserva de vuelo no existe");

                var existe = await context.ReservaVuelos.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

            }

            context.Update(reservaVuelo);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var ReservaVuelo = await context.ReservaVuelos.FirstOrDefaultAsync(x => x.Id == id);
            if (ReservaVuelo == null)
            {
                return NotFound();

            }
            context.Remove(ReservaVuelo);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}