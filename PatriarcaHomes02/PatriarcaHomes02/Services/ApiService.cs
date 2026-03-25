using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

//info de:https://es.linkedin.com/pulse/consumir-una-api-desde-net-maui-melquiades-ma%C3%ADllo-msyif

namespace PatriarcaHomes02.Services
{
    public class ApiService
    {
        private readonly HttpClient conexionHttp;
        private string urlConexion;
        public ApiService()
        {


            urlConexion = Configuration.ApiConstants.ApiUrl;


            // Obtenemos el "permiso" para certificados inseguros
            HttpClientHandler insecureHandler = GetInsecureHandler();

            // Creamos el cliente usando ese permiso
            conexionHttp = new HttpClient(insecureHandler);
            conexionHttp.BaseAddress = new Uri(urlConexion);

            // 3. Configuración de JSON (opcional pero recomendada)
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        // El método de tu imagen para saltarse la validación SSL en desarrollo
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }



        // --- MÉTODOS PARA CONSUMIR LA API ---

        // Metodo para obtener datos (GET)
        public async Task<T?> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await conexionHttp.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Configuración para que "name" (Laravel) entre en "Name" (C#)
                    // y para que no explote con los nulos que trae tu JSON
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        NumberHandling = JsonNumberHandling.AllowReadingFromString
                    };

                    return JsonSerializer.Deserialize<T>(content, options);
                }
                return default;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GET {endpoint}: {ex.Message}");
                return default;
            }
        }

        // 2. Metodo para enviar datos (POST)
        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await conexionHttp.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                }
                return default;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en POST {endpoint}: {ex.Message}");
                return default;
            }
        }
    }
}
