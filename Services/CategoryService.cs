using NotesApp_2.Data.Entities;
using NotesApp_2.Repositories;

namespace NotesApp_2.Services;

public class CategoryService : ICategoryService
{
    
    private readonly ICategoryRepository _categoryRepo;

    public CategoryService(INoteRepository noteRepo, ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }
    
    public async Task CreateCategoryAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("text can't be empty");
        
        if (name.Length > 50)
            throw new ArgumentException("text can't be more than 50");
        
        if (await _categoryRepo.ExistsAsync(name))
            throw new InvalidOperationException($"Категория '{name}' уже существует");
        
        
        var newCategory = new Category() { Name = name };
        await _categoryRepo.AddAsync(newCategory);
    }

    public async Task<List<Category>> GetAllCategoriesAsync() => await _categoryRepo.GetAllAsync();

    public async Task<Category> GetCategoryByIdAsync(int id) => await _categoryRepo.GetByIdAsync(id);
}