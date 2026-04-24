using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WeatherDash.Api;

namespace WeatherDash.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        // 1. Aquí va tu llave de OpenWeather
        private readonly string _apiKey = "1fd6bab3b1fc1c86f9043ccdb799532f";

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            // 2. HttpClient es nuestro "mensajero" para ir a buscar datos a internet
            using (var client = new HttpClient())
            {
                try
                {
                    // 3. Construimos la URL con la ciudad que tú escribas y tu llave
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

                    // 4. Hacemos la petición y esperamos la respuesta
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        // 5. Convertimos el JSON (texto) a objetos de C# (Clases)
                        var weatherData = JsonSerializer.Deserialize<WeatherResponse>(json, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        // 6. Devolvemos solo lo que nos interesa de forma limpia
                        return Ok(new
                        {
                            Ciudad = weatherData.Name,
                            Temperatura = $"{weatherData.Main.Temp} °C",
                            Humedad = $"{weatherData.Main.Humidity}%",
                            Mensaje = "Datos obtenidos en tiempo real"
                        });
                    }

                    return NotFound($"No pudimos encontrar el clima para: {city}");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al conectar con el servicio de clima: {ex.Message}");
                }
            }
        }
    }
}