using Courses_WebAPI.Entities;
using Courses_WebAPI.GraphQL.Mutations;

namespace Courses_WebAPI.GraphQL.ObjectTypes;

public class CourseMutationType : ObjectType<CourseMutation>
{
    protected override void Configure(IObjectTypeDescriptor<CourseMutation> descriptor)
    {
        descriptor.Field(f => f.CreateCourse(default));
    }
}
