using NotesApp_2.Data.Entities;

namespace NotesApp_2.Repositories;

public interface INoteRepository : IRepository<Note>
{
    Task<List<Note>> GetAllWithCategoriesAsync(); // Заметки + категории
    Task<List<Note>> SearchByTitleAsync(string searchTerm); // Поиск по названию
}