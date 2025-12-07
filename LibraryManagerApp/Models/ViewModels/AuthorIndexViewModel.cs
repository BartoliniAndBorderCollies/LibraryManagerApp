using System.Collections.Generic;

namespace LibraryManagerApp.Models.ViewModels
{
    public class AuthorIndexViewModel
    {
        public List<Author> Authors { get; set; }
        public Author NewAuthor { get; set; } = new Author(); // pusty dla formularza
    }
}
