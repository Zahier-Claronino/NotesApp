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
            var newNote = new NoteItem { Title = NoteTitleEntry.Text, Content = NoteDescriptionEntry.Text };
            await database.AddNotesAsync(newNote);
            newNotes.Add(newNote);
            NoteTitleEntry.Text = "";
            NoteDescriptionEntry.Text = "";
        }
    }
}