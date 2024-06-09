﻿using Microsoft.AspNetCore.Mvc;
using ServerSideEx4.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSideEx4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        // GET: api/<InstructorController>
        [HttpGet]
        public IEnumerable<Instructor> Get()
        {
            return Instructor.Read();
        }

        // GET api/<InstructorController>/5
        [HttpGet("{id}")]
        public IEnumerable<Course> GetInstructorCourses(int id)
        {
            Course course = new Course();
            return course.InstructorCourses(id);
        }

        // POST api/<InstructorController>
        [HttpPost]
        public void Post([FromBody] Instructor instructor)
        {
            instructor.AddInstructor();
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = Instructor.Delete(id);
            if (result == 1)
                return Ok(id);
            else return NotFound("There is no Course with this id:" + id);
        }
    }
}
