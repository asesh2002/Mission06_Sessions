using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Sessions.Models;

public class Category
{
    [Key]
    [Required]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    
    public List<Movie> Movies { get; set; }
}