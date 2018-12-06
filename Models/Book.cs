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
            e_tb.OwnsOne(e => e.EnglishInfo);
            e_tb.OwnsOne(e => e.JapaneseInfo);
            e_tb.OwnsOne(e => e.ChineseInfo);
        }
    }
}
