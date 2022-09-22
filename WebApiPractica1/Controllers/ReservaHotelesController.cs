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
    public class ReservaHotelesController : Controller
    {

        private readonly ILogger<ReservaHotelesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReservaHotelesController(ILogger<ReservaHotelesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // select * from genero

        [HttpGet]

        public async Task<ActionResult<List<ReservaHotel>>> Get()
        {
            return await context.ReservaHoteles.ToListAsync();

        }

        [HttpGet("(id:int)")]

        public async Task<ActionResult<ReservaHotelDTO>> Get(int Id)
        {
            var ReservaHotel = await context.ReservaHoteles.FirstOrDefaultAsync(x => x.Id == Id);

            if (ReservaHotel == null)
            {
                return NotFound();
            }
            return mapper.Map<ReservaHotelDTO>(ReservaHotel);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ReservaHotelCreacionDTO reservaHotelCreacionDTO)
        {
            var reservaHotel = mapper.Map<ReservaHotelDTO>(reservaHotelCreacionDTO);
            context.Add(reservaHotel);
            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(ReservaHotel reservaHotel, int id)
        {
            if (reservaHotel.Id != id)
            {
                return BadRequest("Esta reserva  no existe");

                var existe = await context.ReservaHoteles.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

            }

            context.Update(reservaHotel);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var ReservaHotel = await context.ReservaHoteles.FirstOrDefaultAsync(x => x.Id == id);
            if (ReservaHotel == null)
            {
                return NotFound();

            }
            context.Remove(ReservaHotel);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}