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
    public class VuelosController : Controller
    {

        private readonly ILogger<VuelosController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;


        public VuelosController(ILogger<VuelosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // select * from genero

        [HttpGet]

        public async Task<ActionResult<List<Vuelo>>> Get()
        {
            return await context.Vuelos.ToListAsync();

        }

        [HttpGet("(id:int)")]

        public async Task<ActionResult<VueloDTO>> Get(int Id)
        {
            var Vuelo = await context.Vuelos.FirstOrDefaultAsync(x => x.Id == Id);

            if (Vuelo == null)
            {
                return NotFound();
            }
            return mapper.Map<VueloDTO>(Vuelo);
        }
        
        [HttpPost]
        
        public async Task<ActionResult> Post([FromBody] VueloCreacionDTO vueloCreacionDTO)
        {
            var vuelo = mapper.Map<VueloDTO>(vueloCreacionDTO);
            context.Add(vuelo);
            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Vuelo vuelo, int id)
        {
            if (vuelo.Id != id)
            {
                return BadRequest("El vuelo no existe");

                var existe = await context.Vuelos.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

            }

            context.Update(vuelo);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var Vuelo = await context.Vuelos.FirstOrDefaultAsync(x => x.Id == id);
            if (Vuelo == null)
            {
                return NotFound();

            }
            context.Remove(Vuelo);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
