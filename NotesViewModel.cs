using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    public class NotesViewModel : INotifyPropertyChanged
    {

        private readonly DatabaseHelper database = new DatabaseHelper();

        public ObservableCollection<NoteItem> newNotes { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public NotesViewModel()
        {
            newNotes = new ObservableCollection<NoteItem>();
            LoadNotes();
        }

        private async void LoadNotes()
        {
            var noteList = await database.GetNotesAsync();
            newNotes.Clear();
            foreach (var note in noteList)
            {
                newNotes.Add(note);
            }
        }

        protected void OnPorpertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
