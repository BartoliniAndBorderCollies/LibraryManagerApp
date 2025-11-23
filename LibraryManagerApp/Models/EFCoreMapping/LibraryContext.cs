using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Models.EFCoreMapping
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }


        //moje encje, które mają być mapowane przez EF Core:
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book_Author> BooksAuthors { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        //Ręczne wskazanie, że w klasie Ksiazka_Autor ma dwa klucze główne (w sensie te dwa pola razem mają być kluczem głównym)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasKey(ka => new { ka.BookId, ka.AuthorId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
