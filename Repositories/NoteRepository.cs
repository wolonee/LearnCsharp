using Microsoft.EntityFrameworkCore;
using NotesApp_2.Data;
using NotesApp_2.Data.Entities;

namespace NotesApp_2.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly AppDbContext _context;

    public NoteRepository(AppDbContext context) => _context = context;

    
    // -----------------    CRUD    ---------------------
    public async Task<Note> GetByIdAsync(int id) => await _context.Notes.FirstOrDefaultAsync(n => n.Id == id); 
    public async Task<List<Note>> GetAllAsync() => await _context.Notes.ToListAsync();

    public async Task AddAsync(Note entity)
    {
        await _context.Notes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Note entity)
    {
        _context.Notes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Note note = await GetByIdAsync(id);
        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
    }
    
    // ----------------------------------------------------
    
    public async Task<List<Note>> GetAllWithCategoriesAsync()  // Заметки + категории
    {
        return await _context.Notes
            .Include(n => n.Category)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
        // Заметки + категории
    }

    public async Task<List<Note>> SearchByTitleAsync(string searchTerm)  // Поиск по названию
    {
        return await _context.Notes
            .Where(n => n.Title.Contains(searchTerm))
            .Include(n => n.Category)
            .ToListAsync();
    }   
}