using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPILab.Data;
using Newtonsoft.Json;


namespace MovieAPILab.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : Controller
    { 
         private readonly MovieAPILabContext _context;

    public MovieController(MovieAPILabContext context)
    {
        _context = context;
    }

        
        [HttpGet]
        public async Task<string> Index()
        {
           
            return Newtonsoft.Json.JsonConvert.SerializeObject(await _context.Movie.ToListAsync());

        }

        [HttpPost]
       
        public async Task Create([Bind("Title,Genre,Runtime")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                
            }
        }


        [HttpPut]
        public async Task Edit([Bind("Id,Title,Genre,Runtime")] Movie movie)
        {
           
            if (ModelState.IsValid)
            {                
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }

        }
        

        [HttpDelete]
        public async Task Delete(int id)
        {
            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }

        



    }
}
