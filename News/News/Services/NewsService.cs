using News.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace News.Services
{
    public class NewsService : INewsService, IDisposable
    {

        private bool disposedValue;

        const string UriBase = "https://newsapi.org/v2";

        readonly HttpClient httpClient = new()
        {
            BaseAddress = new(UriBase),
            DefaultRequestHeaders = { { "user-agent", "mauiprojects-news/1.0" } }
        };

        /**
         * Es el metodo que vamos a llamar desde el resto de la app
         * Recibe un parametro llamado scope (el enum que creamos)
         * Primero averigua a qué dirección de internet tiene que llamar 
         * pidiéndole la URL al método GetUrl. 
         * Luego usa el HttpClient para descargar los datos
         *
         */
        public async Task<NewsResult> GetNews(NewsScope scope)
        {
            NewsResult result;
            string url = GetUrl(scope);
            try
            {
                result = await httpClient.GetFromJsonAsync<NewsResult>(url);
            }
            catch (Exception ex)
            {
                result = new()
                {
                    Articles = new() { new() { Title =
                    $"HTTP Get failed: {ex.Message}", PublishedAt = DateTime.Now} }
                };
            }
            return result;
        }

        private string GetUrl(NewsScope scope) => scope switch
        {
            NewsScope.Headlines => Headlines,
            NewsScope.Global => Global,
            NewsScope.Local => Local,
            _ => throw new Exception("Undefined scope")
        };
        private static string Headlines =>
            $"{UriBase}/top-headlines?country=us&apiKey={Settings.NewsApiKey}";

        private static string Local =>
            $"{UriBase}/everything?q=local&apiKey={Settings.NewsApiKey}";

        private static string Global =>
            $"{UriBase}/everything?q=global&apiKey={Settings.NewsApiKey}";



        /**
         * Se encarga de cerrar el HttpClient correctamente para que no se quede 
         *  "colgado" en la memoria del dispositivo.
         */
        protected virtual void Dispose(bool disposing)
        {
            // Si ya se liberó antes, no hacemos nada (evita errores)
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Cerramos la conexión de internet del cliente HTTP
                    httpClient.Dispose();
                }

                // Marcamos que el recurso ya está limpio
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in
            //'Dispose(bool disposing)' method

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
