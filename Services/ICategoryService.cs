using NotesApp_2.Data.Entities;

namespace NotesApp_2.Services;

public interface ICategoryService
{
    Task CreateCategoryAsync(string name); // Создание с валидацией
    Task<List<Category>> GetAllCategoriesAsync(); // Список категорий
    Task<Category> GetCategoryByIdAsync(int id); // Получение по ID
}