using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
        {
            
        }        

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LoansJournal> Loans { get; set; }

    }
}
