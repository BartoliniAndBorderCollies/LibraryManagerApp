namespace LibraryManagerApp.Models.ViewModels
{
    public class BookIndexViewModel
    {

        public List<Book> Books { get; set; } = new List<Book>();
        public Book NewBook { get; set; } = new Book();
        public int? EditingBookId { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
