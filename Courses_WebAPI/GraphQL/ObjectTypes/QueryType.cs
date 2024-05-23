using Courses_WebAPI.Entities;

namespace Courses_WebAPI.GraphQL.ObjectTypes;

public class QueryType : ObjectType<CourseQuery>
{
    protected override void Configure(IObjectTypeDescriptor<CourseQuery> descriptor)
    {
        descriptor.Authorize();
        descriptor.Field(f => f.GetCourses(default!)).Authorize();
        descriptor.Field(f => f.GetOneCourses(default!, default!)).Authorize();
    }
}
