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
            NotesListView.ItemsSource = newNotes;
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
            /*newNotes.Clear();
            await database.DeleteAllAsync();*/

        }

        private async void OnClickDeleteNote(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is NoteItem noteToDelete)
            {
                bool confirm = await DisplayAlert("Delete", $"Delete '{noteToDelete.Title}'?", "Yes", "No");
                if (confirm)
                {
                    await database.DeleteNotesAsync(noteToDelete);
                    newNotes.Remove(noteToDelete);
                }
            }
        }

        private async void OnClickViewNote(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNotePage());
        }


        
    }

}
