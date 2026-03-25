using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PatriarcaHomes02.Models
{
    public class Reserva
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("hora")]
        public TimeSpan? Hora { get; set; }

        [JsonPropertyName("user_id")]
        public int? User_id { get; set; }

        [JsonPropertyName("created_by")]
        public int? Created_by { get; set; }

        [JsonPropertyName("updated_by")]
        public int? Updated_by { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime Updated_at { get; set; }


        // ---  CAMPOS DEL JOIN (USUARIOS= ---

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("vivienda")]
        public string Vivienda { get; set; }

        [JsonPropertyName("fecha_reserva")]
        public string FechaReserva { get; set; }
    }
}
