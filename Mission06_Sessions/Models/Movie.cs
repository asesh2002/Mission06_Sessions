using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission06_Sessions.Models;

public class Movie
{
// form items go here
    [Key]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Category selection is required.")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; } 

    [Required(ErrorMessage = "Please enter a title")] 
    public string? Title { get; set; }
    

    [Required, Range(1888, 2025, ErrorMessage = "Please enter a Year")]
    public int? Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    [Required]
    public bool? Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "Please enter a value")]
    public int? CopiedToPlex { get; set; }

    [StringLength(25)] 
    public string? Notes { get; set; }

    
}

