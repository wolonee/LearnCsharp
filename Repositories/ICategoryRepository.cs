using NotesApp_2.Data.Entities;

namespace NotesApp_2.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByNameAsync(string name); // Поиск по названию
    Task<bool> ExistsAsync(string name); // Проверка существования (для валидации)
}