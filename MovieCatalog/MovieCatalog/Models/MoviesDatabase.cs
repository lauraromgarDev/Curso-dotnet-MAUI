using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalog.Models
{
    // 'internal' significa que solo se puede ver dentro de este proyecto.
    // 'static' significa que no necesitas crear un "new MoviesDatabase()", la usas directamente.
    internal static class MoviesDatabase
    {
        // 'async Task<IEnumerable<Movie>>' indica que es un método asíncrono que devolverá 
        // una colección de películas en el futuro (cuando termine de leer el archivo).
        //IEnumerable<Movie> es una interfaz que representa una colección de objetos Movie
        //que se pueden enumerar (como una lista).
        public async static Task<IEnumerable<Movie>> GetMovies()
        {
            // 1. ABRIR EL ARCHIVO:
            // FileSystem.OpenAppPackageFileAsync busca en la carpeta "Resources/Raw" de tu proyecto MAUI.
            // 'using' asegura que el archivo se cierre automáticamente cuando terminemos de usarlo.
            using Stream stream = await FileSystem.OpenAppPackageFileAsync("data.json");

            // 2. CONFIGURAR EL LECTOR (SERIALIZADOR):
            // Le decimos al lector que no sea estricto con las mayúsculas/minúsculas del JSON.
            System.Text.Json.JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true,
            };

            // 3. CONVERTIR JSON A OBJETOS C#:
            // Leemos el stream y lo transformamos en una lista de objetos 'Movie'.
            IEnumerable<Movie>? movies = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Movie>>(stream, options);

            // 4. EVITAR NULOS:
            // Si el archivo estaba vacío o hubo un error, devolvemos una lista vacía '[]' 
            // en lugar de un 'null', para que la app no explote.
            return movies ?? [];
        }
    }
}