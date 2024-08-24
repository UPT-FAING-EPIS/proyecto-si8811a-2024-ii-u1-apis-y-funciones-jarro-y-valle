using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace proyecto_si8811a_2024_ii_u1_desarrollo_api_back.Models
{
    public class Evento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nombre { get; set; }
        public List<string> Equipos { get; set; }
        public string ResultadoId { get; set; }
        public string FixtureId { get; set; }
        public List<string> Actividades { get; set; }
    }
}
