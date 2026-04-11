namespace LibraryManagerApp.Models.ViewModels
{
    public class BookIndexViewModel
    {

        public List<Book> Books { get; set; } = new List<Book>();
        public Book Book { get; set; } = new Book();
    }
}
