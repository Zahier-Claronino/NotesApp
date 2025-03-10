using System.Collections.ObjectModel;

namespace NotesApp;


public partial class AddNotePage : ContentPage
{
    private DatabaseHelper database;
    private NotesViewModel viewModel;

    private NoteItem noteToEdit;

    
    public AddNotePage(NoteItem? note = null)
	{
		InitializeComponent();
        database = new DatabaseHelper();
        viewModel = new NotesViewModel();

        if (note != null)
        {
            noteToEdit = note;
            NoteTitleEntry.Text = note.Title;
            NoteDescriptionEntry.Text = note.Content;
        }



    }


    private async void AddNoteClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(NoteTitleEntry.Text))
        {
            DateTime now = DateTime.Now;
            var newNote = new NoteItem { Title = NoteTitleEntry.Text, Content = NoteDescriptionEntry.Text, Date = now };
            await database.AddNotesAsync(newNote);
            viewModel.newNotes.Add(newNote);
            

            await DisplayAlert("Success", "Note saved successfully", "Ok");

            await Navigation.PushAsync(new MainPage());

        }
    }
}