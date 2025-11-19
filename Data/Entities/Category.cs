using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace NotesApp_2.Data.Entities;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public List<Note> Notes { get; set; } = new();
}