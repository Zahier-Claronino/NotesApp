using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    public class ViewModel
    {
        public ObservableCollection<NoteItem> newNotes = new ObservableCollection<NoteItem>();

        public ViewModel()
        {
            newNotes = new ObservableCollection<NoteItem>(); 
        }
    }
}
