using Courses_WebAPI.DataContexts;
using Courses_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace Courses_WebAPI.GraphQL;

public class CourseQuery
{
    public async Task<List<CoursesEntity>> GetCourses([Service] DataContext context)
    {
        return await context.Courses.ToListAsync();

    }

    public async Task<CoursesEntity?> GetOneCourses([Service] DataContext context, string id)
    {

       return await context.Courses.FindAsync(id);
    }
}
