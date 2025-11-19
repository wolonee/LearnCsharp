using Microsoft.EntityFrameworkCore;
using NotesApp_2.Data;
using NotesApp_2.Data.Entities;

namespace NotesApp_2.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context) => _context = context;

    public async Task<Category> GetByIdAsync(int id) => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<List<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

    public async Task AddAsync(Category entity)
    {
        await _context.Categories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category entity)
    {
        
    }
    
    public async Task DeleteAsync(int id)
    
    public Task<Category?> GetByNameAsync(string name); // Поиск по названию
    public Task<bool> ExistsAsync(string name); // Проверка существования (для валидации)
}