using Courses_WebAPI.DataContexts;
using Courses_WebAPI.Entities;
using Courses_WebAPI.Services;
namespace Courses_WebAPI.GraphQL.Mutations;

public class CourseMutation(DataContext context)
{
    public async Task<CoursesEntity> CreateCourse(CoursesEntity course)
    {
        course.Id = Guid.NewGuid().ToString();
        context.Courses.Add(course);
        await context.SaveChangesAsync();
        return course;

    }

}
