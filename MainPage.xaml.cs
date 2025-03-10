using System.Collections.ObjectModel;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System;

using NotesApp;
using System.Security.Cryptography.X509Certificates;

namespace NotesApp
{
    public partial class MainPage : ContentPage
    {
        private NotesViewModel viewModel = new NotesViewModel();
        private DatabaseHelper database = new DatabaseHelper();
 

        public MainPage()
        {
            
            InitializeComponent();

            viewModel = new NotesViewModel();
            BindingContext = viewModel;
            NotesCollectionView.ItemsSource = viewModel.newNotes;

            database = new DatabaseHelper();



        }
        protected override bool OnBackButtonPressed()
        {
            // Exit the application when back button is pressed on MainPage
            Application.Current.Quit();
            return true; // Indicate that the back button press has been handled
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
                    viewModel.newNotes.Remove(noteToDelete);
                }
            }
        }

        private async void OnClickViewNote(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is NoteItem noteToView)
            {
                await Navigation.PushAsync(new ViewNotePage(noteToView));
            }
        }


        
    }

}
