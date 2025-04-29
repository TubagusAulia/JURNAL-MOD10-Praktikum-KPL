using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modul10_103022300141.Models;

namespace modul10_103022300141.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabont", new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton"}, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola", new List<string>{"Marlon Brando", "Al Pacino", "James Caan"}, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christoper Nolan", new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"}, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };

        // GET /api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            return Ok(movies);
        }

        // GET /api/Movie/{id}
        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            if (id < 0 || id >= movies.Count)
            {
                return NotFound();
            }

            return Ok(movies[id]);
        }

        // POST /api/Movie
        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            movies.Add(movie);
            return CreatedAtAction(nameof(GetById), new { id = movies.Count - 1 }, movie);
        }

        // DELETE /api/Movie/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= movies.Count)
            {
                return NotFound();
            }

            var deleted = movies[id];
            movies.RemoveAt(id);
            return Ok(deleted);
        }
    }


}
