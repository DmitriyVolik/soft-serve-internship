using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace DAL.Entities;

public class Genre
{
    [Key]
    public GenreEnum Id { get; set; }
    
    [MaxLength(20)]
    public string Name { get; set; }
}