using System.Collections.ObjectModel;

namespace NotesApp;


public partial class AddNotePage : ContentPage
{
    private readonly DatabaseHelper database = new DatabaseHelper();
    private ObservableCollection<NoteItem> newNotes = new ObservableCollection<NoteItem>();
    public AddNotePage()
	{
		InitializeComponent();
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

    private async void AddNoteClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(NoteTitleEntry.Text))
        {
            DateTime now = DateTime.Now;
            var newNote = new NoteItem { Title = NoteTitleEntry.Text, Content = NoteDescriptionEntry.Text, Date = now };
            await database.AddNotesAsync(newNote);
            newNotes.Add(newNote);
            

            await DisplayAlert("Success", "Note saved successfully", "Ok");

            await Navigation.PushAsync(new MainPage());


        }
    }
}