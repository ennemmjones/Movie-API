using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using Newtonsoft.Json;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetMovies()
        { 
            using (HttpClient client = new HttpClient())
            {
                var url = "https://localhost:44316/movie/";
                HttpResponseMessage message = await client.GetAsync(url);
                                
                var model = JsonConvert.DeserializeObject<List<Movie>>(await message.Content.ReadAsStringAsync());
                //ViewBag.Result = await message.Content.ReadAsStringAsync();
                
                return View(model);
            }
                                   
        }

        public async Task<IActionResult> Details(int id)
        {

            var movie = new Movie();
            using (HttpClient client = new HttpClient())
            {
                var url = "https://localhost:44316/movie/";
                HttpResponseMessage message = await client.GetAsync(url);

                var model = JsonConvert.DeserializeObject<List<Movie>>(await message.Content.ReadAsStringAsync());
                movie = model.Find(m => m.Id == id);

                return View(movie);
            }

        }

        public async Task<IActionResult> PostMovies([Bind("Title,Genre,Runtime")] Movie movie)
        {
           
            
            using (HttpClient client = new HttpClient())
            {
                var content = JsonContent.Create(movie);
                var url = "https://localhost:44316/movie/";
                HttpResponseMessage message = await client.PostAsync(url, content);
                                
                return View();
            }

        }


        public async Task<IActionResult> UpdateMovies(int id)
        {
            
            var movie = new Movie(); 
            using (HttpClient client = new HttpClient())
            {
                var url = "https://localhost:44316/movie/";
                HttpResponseMessage message = await client.GetAsync(url);

                var model = JsonConvert.DeserializeObject<List<Movie>>(await message.Content.ReadAsStringAsync());
                movie = model.Find(m => m.Id == id);

                return View(movie);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMovies([Bind("Id","Title,Genre,Runtime")] Movie movie)
        {


            using (HttpClient client = new HttpClient())
            {
                var content = JsonContent.Create(movie);
                var url = "https://localhost:44316/movie/";
                HttpResponseMessage message = await client.PutAsync(url, content);

                return View(movie);
            }

        }


        public async Task<IActionResult> DeleteMovies(int id)
        {

            var movie = new Movie();
            using (HttpClient client = new HttpClient())
            {
                var url = "https://localhost:44316/movie/";
                HttpResponseMessage message = await client.GetAsync(url);

                var model = JsonConvert.DeserializeObject<List<Movie>>(await message.Content.ReadAsStringAsync());
                movie = model.Find(m => m.Id == id);

                return View(movie);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovies([Bind("Id","Title,Genre,Runtime")] Movie movie)
        {


            using (HttpClient client = new HttpClient())
            {
                
                var url = "https://localhost:44316/movie/";
                HttpResponseMessage message = await client.DeleteAsync($"{url}?id={movie.Id}");

                return View();
            }

        }






    }
}
    
