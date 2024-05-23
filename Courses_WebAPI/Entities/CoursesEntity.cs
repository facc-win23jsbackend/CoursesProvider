﻿using HotChocolate.Authorization;
using System.ComponentModel.DataAnnotations;
namespace Courses_WebAPI.Entities;

[Authorize]
public class CoursesEntity 
{
    [Key]
    public string Id { get; set; } = null!;
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public bool IsBestseller { get; set; }
    public bool IsDigital { get; set; }
    public string[]? Categories { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public decimal StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesInPercent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public virtual List<AuthorEntity>? Authors { get; set; }
    public virtual PricesEntity? Prices { get; set; }
    public virtual ContentEntity? Content { get; set; }
}
