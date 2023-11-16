using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();
            if(movie == null) { return NotFound(); }
            else { return Ok(movie); }
            
        }

        // POST api/<MoviesController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return StatusCode(201, movie);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.Movie updatedMovie)
        {
            var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();
            if (movie == null) { return NotFound(); }
            else
            {
                if (movie.Title != updatedMovie.Title) { movie.Title = updatedMovie.Title; }
                if (updatedMovie.RunningTime != null) { movie.RunningTime = updatedMovie.RunningTime; }
                if (movie.Genre != updatedMovie.Genre) { movie.Genre = updatedMovie.Genre; }
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return Ok(movie);
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).SingleOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
