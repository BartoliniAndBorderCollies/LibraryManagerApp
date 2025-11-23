using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Category
    {
        [Key]
        [Column("id_kategorii")]
        public int CategoryId { get; set; }

        [Required]
        [Column("Nazwa")]
        public string Name {  get; set; }

        //nawigacyjna wlasciwosc
        public ICollection<Book> BooksList { get; set; }
        
    }
}
