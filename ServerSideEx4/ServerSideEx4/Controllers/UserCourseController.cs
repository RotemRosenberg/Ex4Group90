using Microsoft.AspNetCore.Mvc;
using ServerSideEx4.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSideEx4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        // GET: api/<UserCourseController>
        [HttpGet]
        public IEnumerable<UserCourse> Get()
        {
            return UserCourse.Read();      
        }

        // GET api/<UserCourseController>/5
        [HttpGet("{id}")]
        public IEnumerable<Course> Get(int id)
        {
            return UserCourse.ReadAllUserCourses(id);
        }

        // POST api/<UserCourseController>
        [HttpPost]
        public bool Post([FromBody] UserCourse userCourse)
        {
            return userCourse.Insert();
        }

        // PUT api/<UserCourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserCourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
