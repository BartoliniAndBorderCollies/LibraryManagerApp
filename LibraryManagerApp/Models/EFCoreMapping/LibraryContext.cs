using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Models.EFCoreMapping
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }


        //moje encje, które mają być mapowane przez EF Core:
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Czytelnik> Czytelnicy { get; set; }
        public DbSet<Kategoria> Kategorie {  get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Ksiazka_Autor> KsiazkiAutorzy { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        //Ręczne wskazanie, że w klasie Ksiazka_Autor ma dwa klucze główne (w sensie te dwa pola razem mają być kluczem głównym)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ksiazka_Autor>()
                .HasKey(ka => new { ka.IdKsiazki, ka.IdAutora });

            base.OnModelCreating(modelBuilder);
        }

    }
}
