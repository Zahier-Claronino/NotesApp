using System.Collections.ObjectModel;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System;

using NotesApp;

namespace NotesApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseHelper database = new DatabaseHelper();    
        private ObservableCollection<NoteItem> newNotes = new ObservableCollection<NoteItem>();

        public MainPage()
        {
            InitializeComponent();
            LoadNotes();
        }

        private async void LoadNotes()
        {
            var noteList = await database.GetNotesAsync();
            newNotes.Clear();
            foreach(var note in noteList)
            {
                newNotes.Add(note);
            }
        }

        private async void AddNoteMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNotePage());

        }


        private async void ViewNoteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewNotes());
        }
    }

}
