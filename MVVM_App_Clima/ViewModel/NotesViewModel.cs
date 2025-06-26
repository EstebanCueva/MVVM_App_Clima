using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_App_Clima.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace MVVM_App_Clima.ViewModel
{
    public partial class NotesViewModel : ObservableObject
    {
        private readonly AllNotes _allNotes = new AllNotes();

        public ObservableCollection<Note> Notes => _allNotes.Notes;

        [ObservableProperty]
        private string newNoteText;

        [RelayCommand]
        private void AddNote()
        {
            if (string.IsNullOrWhiteSpace(NewNoteText))
                return;

            string filename = Path.Combine(FileSystem.AppDataDirectory, $"{Path.GetRandomFileName()}.notes.txt");
            File.WriteAllText(filename, NewNoteText);

            NewNoteText = string.Empty;
            _allNotes.LoadNotes(); 
        }

        [RelayCommand]
        private void DeleteNote(Note note)
        {
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);

            _allNotes.LoadNotes(); // Recargar notas
        }
    }
}
