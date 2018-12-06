using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestEFCoreOwned.Models {
    public class Info {
        public string Title { get; set; } // a general column
        public string Author { get; set; } // a column specified HasMaxLength() by fluent API
        string Memo { get; set; } // with fluent API, a column can be implemented by a private property

        public static void OnModelCreating<T>(ReferenceOwnershipBuilder<T, Info> rob) where T : class {
            rob.Property(e => e.Title);
            rob.Property(e => e.Author)
                .HasMaxLength(100);
            rob.Property(e => e.Memo);
        }
    }
}
