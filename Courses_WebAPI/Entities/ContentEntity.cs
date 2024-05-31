namespace Courses_WebAPI.Entities;

public class ContentEntity
{
    public string? Description { get; set; }
    public List<string>? Includes { get; set; }
    public List<string>? Learn {  get; set; }
    public virtual List<ProgramDetailItemEntity>? ProgramDetails { get; set; }
}