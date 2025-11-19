namespace NotesApp_2.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id); // Асинхронное получение по ID
    Task<List<T>> GetAllAsync(); // Все записи
    Task AddAsync(T entity); // Добавление
    Task UpdateAsync(T entity); // Обновление
    Task DeleteAsync(int id); // Удаление
}