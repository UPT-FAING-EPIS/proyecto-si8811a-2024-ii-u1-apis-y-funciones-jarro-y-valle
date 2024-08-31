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

        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }

        public string Facultad { get; set; }
    }
}
