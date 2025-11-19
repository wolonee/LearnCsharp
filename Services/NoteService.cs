using NotesApp_2.Data;
using NotesApp_2.Data.Entities;
using NotesApp_2.Repositories;

namespace NotesApp_2.Services;
namespace NotesApp_2.Repositories;


class NoteService
{
    private readonly INoteRepository _noteRepo;
    private readonly ICategoryRepository _categoryRepo;

    public NoteService(INoteRepository noteRepo, ICategoryRepository categoryRepo)
    {
        _noteRepo = noteRepo;
        _categoryRepo = categoryRepo;
    }
    
    public async Task CreateNoteAsync(string title, string content, string categoryName)
    {
        // 1. Валидация
        if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(content) && string.IsNullOrWhiteSpace(categoryName))
            throw new ArgumentException("text can't be null or space");
        
        if (title.Length > 50)
            throw new ArgumentException("title can't be more than 50");

        // 2. Поиск категории
        var category = await _categoryRepo.GetByNameAsync(categoryName);
        if (category == null)
            throw new KeyNotFoundException($"Категория '{categoryName}' не найдена");

        // 3. Создание заметки
        var newNote = new Note
        {
            Title = title,
            Content = content,
            Category = category,
            CreatedAt = DateTime.UtcNow
        };
    }

    public async Task<List<Note>> GetAllNotesAsync()
    {
        
    }
    
    public async Task<List<Note>> SearchNotesAsync(string searchTerm);
}