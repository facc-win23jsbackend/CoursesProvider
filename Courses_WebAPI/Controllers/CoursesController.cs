using Courses_WebAPI.DataContexts;
using Courses_WebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courses_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly DataContext _context;

        public CoursesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<CoursesEntity>> CreateCourse([FromBody] CoursesEntity course)
        {
            if (_context.Courses.Any(x => x.Title == course.Title))
            {
                return BadRequest("A course with this name already exists");
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoursesEntity>>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CoursesEntity>> GetCourse(string id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound("Could not find any courses with that id");
            }

            return course;

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CoursesEntity>> DeleteCourse(string id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
