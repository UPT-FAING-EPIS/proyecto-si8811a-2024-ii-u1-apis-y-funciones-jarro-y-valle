using Microsoft.Extensions.Options;
using MongoDB.Driver;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Models;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Settings;



namespace proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Services
{
    public class EventoService
    {
        private readonly IMongoCollection<Evento> _eventos;

        public EventoService(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _eventos = database.GetCollection<Evento>("Evento");
        }

        public async Task<List<Evento>> GetAsync() =>
            await _eventos.Find(e => true).ToListAsync();

        public async Task<Evento> GetByIdAsync(string id) =>
            await _eventos.Find<Evento>(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<Evento> CreateAsync(Evento nuevoEvento)
        {
            await _eventos.InsertOneAsync(nuevoEvento);
            return nuevoEvento;
        }

        public async Task<Evento> UpdateAsync(string id, Evento evento)
        {
            await _eventos.ReplaceOneAsync(a => a.Id == id, evento);
            return evento;
        }

        public async Task DeleteAsync(string id) =>
            await _eventos.DeleteOneAsync(e => e.Id == id);
    }
}
