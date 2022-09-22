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
    public class HotelesController : Controller
    {

        private readonly ILogger<HotelesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HotelesController(ILogger<HotelesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        // select * from genero

        [HttpGet]

        public async Task<ActionResult<List<Hotel>>> Get()
        {
            return await context.Hoteles.ToListAsync();

        }

        [HttpGet("(id:int)")]

        public async Task<ActionResult<HotelDTO>> Get(int Id)
        {
            var Hotel = await context.Hoteles.FirstOrDefaultAsync(x => x.Id == Id);

            if (Hotel == null)
            {
                return NotFound();
            }
            return mapper.Map<HotelDTO>(Hotel);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] HotelCreacionDTO hotelCreacionDTO)
        {
            var hotel = mapper.Map<HotelDTO>(hotelCreacionDTO);
            context.Add(hotel);
            return NoContent();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Hotel hotel, int id)
        {
            if (hotel.Id != id)
            {
                return BadRequest("Este hotel no existe");

                var existe = await context.Hoteles.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

            }

            context.Update(hotel);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var Hotel = await context.Hoteles.FirstOrDefaultAsync(x => x.Id == id);
            if (Hotel == null)
            {
                return NotFound();

            }
            context.Remove(Hotel);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}