namespace Courses_WebAPI.Entities;

public class ContentEntity
{
    public string? Description { get; set; }
    public virtual List<string>? Includes { get; set; }
    public virtual List<string>? Learn {  get; set; }
    public virtual List<ProgramDetailItemEntity>? ProgramDetails { get; set; }
}