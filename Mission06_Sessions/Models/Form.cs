using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission06_Sessions.Models;

public class Form
{
// form items go here
    [Key] 
    [Required]
    public int FormID { get; set; }

    [Required] 
    public string Category { get; set; }

    [Required] 
    public string Title { get; set; }

    [Required]
    public int Year { get; set; }

    [Required] 
    public string Rating { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }

    [StringLength(25)] 
    public string? Notes { get; set; }

    
}

