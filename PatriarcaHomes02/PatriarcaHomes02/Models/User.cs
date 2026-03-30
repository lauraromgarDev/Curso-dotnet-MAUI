using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PatriarcaHomes02.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; } = "user";

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("remember_token")]
        public string? RememberToken { get; set; }

        // Campos de ubicación
        [JsonPropertyName("portal")]
        public string? Portal { get; set; }

        [JsonPropertyName("bloque")]
        public string? Bloque { get; set; }

        [JsonPropertyName("piso")]
        public string? Piso { get; set; }

        // Campos de auditoría
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("created_by")]
        public long? CreatedBy { get; set; }

        [JsonPropertyName("updated_by")]
        public long? UpdatedBy { get; set; }

        [JsonPropertyName("imagen")]
        public string? Imagen { get; set; }
    }
}
