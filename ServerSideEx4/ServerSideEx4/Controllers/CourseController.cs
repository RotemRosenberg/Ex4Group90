using Microsoft.AspNetCore.Mvc;
using ServerSideEx4.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSideEx4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return Course.Read();
        
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] Course course)
        {
            course.AddCourse();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = Course.Delete(id);
            if (result == 1)
                return Ok(id);
            else return NotFound("There is no Course with this id:" + id);
        }

        [HttpGet("GetByRatingRange/{minRating}/{maxRating}")] // this uses resource routing
        public IEnumerable<Course> GetByRatingRange(float minRating, float maxRating)
        {
            Course course = new Course();
            return course.RatingRange(minRating, maxRating);
        }
        [HttpGet("search")] // this uses the QueryString
        public IEnumerable<Course> GetByDurationRange(float minDuration, float maxDuration)
        {
            Course course = new Course();
            return course.DurationRange(minDuration, maxDuration);

        }
    }
}
