using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace NotesApp
{
    public  class NoteItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content   { get; set; }
        public DateTime Date { get; set; }

        
    }

    
}
