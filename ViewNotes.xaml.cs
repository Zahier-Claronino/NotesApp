

using System.Collections.ObjectModel;

namespace NotesApp;

public partial class ViewNotes : ContentPage
{
    private readonly DatabaseHelper database = new DatabaseHelper();
    private ObservableCollection<NoteItem> newNotes = new ObservableCollection<NoteItem>();
    public ViewNotes()
	{
		InitializeComponent();
        LoadNotes();
        NotesListView.ItemsSource = newNotes;

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
}