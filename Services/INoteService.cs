using NotesApp_2.Data.Entities;

namespace NotesApp_2.Services;

public interface INoteService
{
    Task CreateNoteAsync(string title, string content, string categoryName);
    Task<List<Note>> GetAllNotesAsync(); // Возвращает заметки с категориями
    Task<List<Note>> SearchNotesAsync(string searchTerm);
}