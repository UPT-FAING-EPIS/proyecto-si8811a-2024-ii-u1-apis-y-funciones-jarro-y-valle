using Microsoft.AspNetCore.Mvc;
using proyecto_si8811a_2024_ii_u1_desarrollo_api_back.Models;
using proyecto_si8811a_2024_ii_u1_desarrollo_api_back.Services;

namespace proyecto_si8811a_2024_ii_u1_desarrollo_api_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : Controller
    {
        private readonly EventoService _eventoService;

        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _eventoService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(string id)
        {
            return await _eventoService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> CreateEvento(Evento evento)
        {
            return await _eventoService.CreateAsync(evento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Evento>> UpdateEvento(string id, Evento evento)
        {
            return await _eventoService.UpdateAsync(id, evento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvento(string id)
        {
            await _eventoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
