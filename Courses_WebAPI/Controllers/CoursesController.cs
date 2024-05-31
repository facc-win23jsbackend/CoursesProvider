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

            course.Id = Guid.NewGuid().ToString();
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


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(string id, [FromBody] CoursesEntity updatedCourse)
        {
            var course = await _context.Courses.FindAsync(id);
            if ( course == null)
            {
                return NotFound("Could not find any courses with that id");
            }

            course.ImageUri = updatedCourse.ImageUri;
            course.ImageHeaderUri = updatedCourse.ImageHeaderUri;
            course.IsBestseller = updatedCourse.IsBestseller;
            course.IsDigital = updatedCourse.IsDigital;
            course.Categories = updatedCourse.Categories;
            course.Title = updatedCourse.Title;
            course.Ingress = updatedCourse.Ingress;
            course.StarRating = updatedCourse.StarRating;
            course.Reviews = updatedCourse.Reviews;
            course.LikesInPercent = updatedCourse.LikesInPercent;
            course.Likes = updatedCourse.Likes;
            course.Hours = updatedCourse.Hours;
            course.Prices = updatedCourse.Prices;
            course.Authors = updatedCourse.Authors;
            course.Content = updatedCourse.Content;
           
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound("The course does not exists!");
            }

            return NoContent();
        }
    }
}
