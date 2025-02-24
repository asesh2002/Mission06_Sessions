using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Sessions.Models;

public class Category
{
    [Key]
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
}