namespace LibraryManagerApp.Models.ViewModels
{
    public class ReaderIndexViewModel
    {
        public List<Reader> Readers { get; set; } = new List<Reader>();
        public Reader NewReader { get; set; } = new Reader();
        public int? EditingReaderId { get; set; }

    }
}
