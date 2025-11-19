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
        _context.Categories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Category chooseCategory = await GetByIdAsync(id);
        _context.Categories.Remove(chooseCategory);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Category?> GetByNameAsync(string name) => await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);

    public async Task<bool> ExistsAsync(string name)
    {
        Category? res = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        if (res != null)
            return true;
        else
            return false;
    }
}