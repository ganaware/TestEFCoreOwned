using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestEFCoreOwned.Models {
    public class Info {
        public string Title { get; set; } // a general column
        public string Author { get; set; } // a column specified HasMaxLength() by fluent API
        string Memo { get; set; } // with fluent API, a column can be implemented by a private property

        public static void OnModelCreating(ModelBuilder modelBuilder) {
            EntityTypeBuilder<Info> e_tb = modelBuilder.Entity<Info>();
            e_tb.Property(e => e.Title);
            e_tb.Property(e => e.Author)
                .HasMaxLength(100);
            e_tb.Property(e => e.Memo);
        }
    }
}
