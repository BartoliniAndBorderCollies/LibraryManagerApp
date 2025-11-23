using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Author
    {
        [Key]
        [Column("id_autora")]
        public int AuthorId { get; set; }

        [Required]
        [Column("imie")]
        public string FirstName {  get; set; }

        [Required]
        [Column("nazwisko")]
        public string LastName { get; set; }

        public ICollection<Book_Author> BooksAuthor {  get; set; }
    }
}
