using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection database;

        public DatabaseHelper()
        {
            string DbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db");
            database = new SQLiteAsyncConnection(DbPath);
            database.CreateTableAsync<NoteItem>().Wait();
        }

        public Task<List<NoteItem>> GetNotesAsync()
        {
            return database.Table<NoteItem>().ToListAsync();
        }

        public Task<int> AddNotesAsync(NoteItem notes)
        {
            return database.InsertAsync(notes);
        }

        public Task<int> DeleteNotesAsync(NoteItem notes)
        {
            return database.DeleteAsync(notes);
        }


        public Task<int> UpdateNotesAsync(NoteItem notes)
        {
            return database.UpdateAsync(notes);
        }



    }
}
