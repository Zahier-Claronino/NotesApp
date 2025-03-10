namespace NotesApp;

public partial class ViewNotePage : ContentPage
{
    private NoteItem noteToView;
    private DatabaseHelper database = new DatabaseHelper(); 


    public ViewNotePage(NoteItem note)
    {
        InitializeComponent();
        noteToView = note;

        // Display the note details
        TitleLabel.Text = noteToView.Title;
        DescriptionLabel.Text = noteToView.Content;
        database = new DatabaseHelper();
    }

    private async void UpdateNoteClicked(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        noteToView.Title = TitleLabel.Text;  
        noteToView.Content = DescriptionLabel.Text;
        noteToView.Date = now;

        await database.UpdateNotesAsync(noteToView);
        // Navigate to the AddNotePage for editing
        await Navigation.PushAsync(new MainPage());
    }
}