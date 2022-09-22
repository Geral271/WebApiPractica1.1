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
    public class TuristasController : Controller
    {

        private readonly ILogger<TuristasController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TuristasController(ILogger<TuristasController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // select * from genero

        [HttpGet]

        public async Task<ActionResult<List<Turista>>> Get()
        {
            return await context.Turistas.ToListAsync();

        }

        [HttpGet("(id:int)")]

        public async Task<ActionResult<TuristaDTO>> Get(int Id)
        {
            var Turista = await context.Turistas.FirstOrDefaultAsync(x => x.Id == Id);

            if (Turista == null)
            {
                return NotFound();
            }
            return mapper.Map<TuristaDTO>(Turista);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] TuristaCreacionDTO turistaCreacionDTO)
        {
            var turista = mapper.Map<TuristaDTO>(turistaCreacionDTO);
            context.Add(turista);
            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Turista turista, int id)
        {
            if (turista.Id != id)
            {
                return BadRequest("El turista no esta registrado");

                var existe = await context.Turistas.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

            }

            context.Update(turista);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var Turista = await context.Turistas.FirstOrDefaultAsync(x => x.Id == id);
            if (Turista == null)
            {
                return NotFound();

            }
            context.Remove(Turista);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}