using Courses_WebAPI.DataContexts;
using Courses_WebAPI.GraphQL;
using Courses_WebAPI.GraphQL.Mutations;
using Courses_WebAPI.GraphQL.ObjectTypes;
using Courses_WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseCosmos(builder.Configuration["COSMOS:COSMOS_URI"]!, builder.Configuration["COSMOS:COSMOS_DBNAME"]!)
    .UseLazyLoadingProxies();
});

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddGraphQLServer()
    .RegisterDbContext<DataContext>()
    .AddQueryType<CourseQuery>()
    .AddMutationType<CourseMutationType>();


//var sp = builder.Services.BuildServiceProvider();
//using var scope = sp.CreateScope();
//var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
//using var context = dbContextFactory.CreateDbContext();
//context.Database.EnsureCreated();


var app = builder.Build();
app.MapGraphQL();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

