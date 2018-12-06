using Microsoft.EntityFrameworkCore;

namespace TestEFCoreOwned.Models {
    public class Book {
        public int BookId { get; set; }
        public Info EnglishInfo { get; set; }
        public Info JapaneseInfo { get; set; }
        public Info ChineseInfo { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder) {
            var e_tb = modelBuilder.Entity<Book>();
            e_tb.Property(e => e.BookId);
            e_tb.OwnsOne(e => e.EnglishInfo, cb => Info.OnModelCreating(cb));
            e_tb.OwnsOne(e => e.JapaneseInfo, cb => Info.OnModelCreating(cb));
            e_tb.OwnsOne(e => e.ChineseInfo, cb => Info.OnModelCreating(cb));
        }
    }
}
