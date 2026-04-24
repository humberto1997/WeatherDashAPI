# 🌤️ WeatherDash API

API desarrollada en **.NET 10** para la consulta de clima en tiempo real, integrando servicios externos.

## 🚀 Tecnologías y Conceptos Aplicados
* **ASP.NET Core Web API**: Estructura profesional de endpoints.
* **HttpClient**: Consumo de servicios REST externos (OpenWeatherMap API).
* **Asincronismo (Async/Await)**: Manejo eficiente de peticiones externas sin bloquear el hilo principal.
* **JSON Serialization**: Mapeo dinámico de respuestas JSON a objetos C#.
* **Dependency Injection**: Arquitectura limpia y escalable.

## 🛠️ Cómo probar
1. Clonar el repositorio.
2. Agregar tu API Key de OpenWeather en `WeatherController.cs`.
3. Ejecutar el proyecto y probar en `/api/weather/{ciudad}`.