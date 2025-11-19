// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp_2.Data;
using NotesApp_2.Services;

namespace NotesApp_2.Console;

using System;

class Program
{
    static async Task Main()
    {
        // NotesApp.Console/Program.cs
        static async Task Main() 
        {
            // 1. DI-контейнер (упрощённая версия)
            var dbContext = new AppDbContext();
            await dbContext.Database.MigrateAsync(); // Автомиграции
    
            // var services = new ServiceCollection()
            //     .AddScoped<INoteService, NoteService>()
            //     .AddScoped<ICategoryService, CategoryService>()
            //     .BuildServiceProvider();
    
            // 2. Главное меню
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("📝 МЕНЮ ЗАМЕТОК\n" + new string('=', 30));
                Console.WriteLine("1. 📂 Управление категориями");
                Console.WriteLine("2. ✍️ Создать заметку");
                Console.WriteLine("3. 🔍 Поиск заметок");
                Console.WriteLine("0. ❌ Выход");
        
                var choice = Console.ReadKey().KeyChar;
                switch (choice) 
                {
                    case '1': await ShowCategoryMenu(services); break;
                    case '2': await CreateNoteFlow(services); break;
                    case '3': await SearchNotesFlow(services); break;
                    case '0': return;
                }
            }
        }
    }
}


