namespace Courses_WebAPI.Entities;

public class ContentEntity
{
    public string? Description { get; set; }
    public string[]? Title { get; set; }
    public virtual List<ProgramDetailItemEntity>? ProgramDetails { get; set; }
}