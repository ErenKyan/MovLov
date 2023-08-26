using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovLov.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovLov.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Popular(int page = 1)
        {
            using (var httpClient = new HttpClient())
            {
                string apiKey = "1052854663a600bacacc634e045bbfd4";
                string language = "en-US";

                string apiUrl = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&page={page}&language={language}";

                // Rest of your code
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation($"API Response Content: {responseContent}");


                        var movieResponse = JsonSerializer.Deserialize<TrendingMoviesResponse>(responseContent);

                        if (movieResponse != null && movieResponse.results != null)
                        {
                            _logger.LogInformation("API Response and Results are valid.");
                            return View(movieResponse);
                        }
                        else
                        {
                            if (movieResponse == null)
                            {
                                _logger.LogError("movieResponse is null.");
                            }
                            else if (movieResponse.results == null)
                            {
                                _logger.LogError("movieResponse.Results is null.");
                            }

                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else
                    {
                        _logger.LogError($"API Error: {response.StatusCode}");
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while making API request: {ex.Message}");
                    return RedirectToAction("Index", "Home");
                }
            }
        }


    }
}
