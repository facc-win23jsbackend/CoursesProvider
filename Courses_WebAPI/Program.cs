using Courses_WebAPI.DataContexts;
using Courses_WebAPI.GraphQL;
using Courses_WebAPI.GraphQL.Mutations;
using Courses_WebAPI.GraphQL.ObjectTypes;
using Courses_WebAPI.Services;
using Keycloak.AuthServices.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseCosmos(builder.Configuration["COSMOS:COSMOS_URI"]!, builder.Configuration["COSMOS:COSMOS_DBNAME"]!)
    .UseLazyLoadingProxies();
});

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .RegisterDbContext<DataContext>()
    .AddQueryType<CourseQuery>()
    .AddMutationType<CourseMutationType>();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();
app.Run();

