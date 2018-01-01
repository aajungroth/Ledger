using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Ledger.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LedgerContext(
                serviceProvider.GetRequiredService<DbContextOptions<LedgerContext>>()))
            {
                // Look for any authors.
                if (!context.Author.Any())
                {
                    context.Author.AddRange(
                         new AuthorClass
                         {
                             FirstName = "Stephen",
                             LastName = "King"
                         },

                         new AuthorClass
                         {
                             FirstName = "Joanne",
                             LastName = "Rowling"
                         },

                         new AuthorClass
                         {
                             FirstName = "Ernest",
                             LastName = "Hemingway"
                         },

                         new AuthorClass
                         {
                             FirstName = "Mark",
                             LastName = "Twain"
                         }
                    );
                    context.SaveChanges();
                }

                // Look for any books.
                if (!context.Book.Any())
                {
                    context.Book.AddRange(
                         new BookClass
                         {
                             AuthorID = 1,
                             Title = "test",
                             ISBN = "1",
                             PublishDate = new DateTime(2008, 3, 15)
                         },

                         new BookClass
                         {
                             AuthorID = 1,
                             Title = "test",
                             ISBN = "1",
                             PublishDate = new DateTime(2008, 3, 15)
                         },

                         new BookClass
                         {
                             AuthorID = 1,
                             Title = "test",
                             ISBN = "1",
                             PublishDate = new DateTime(2008, 3, 15),
                         },

                         new BookClass
                         {
                             AuthorID = 1,
                             Title = "test",
                             ISBN = "1",
                             PublishDate = new DateTime(2008, 3, 15)
                         }
                    );
                    context.SaveChanges();
                }

                // Look for any reviews.
                if (!context.Review.Any())
                {
                    context.Review.AddRange(
                         new ReviewClass
                         {
                            BookID = 1,
                            ReviewerName = "Test",
                            Body = "Test"
                         },

                         new ReviewClass
                         {
                            BookID = 1,
                            ReviewerName = "Test",
                            Body = "Test"
                         },

                         new ReviewClass
                         {
                            BookID = 1,
                            ReviewerName = "Test",
                            Body = "Test"
                         },

                         new ReviewClass
                         {
                            BookID = 1,
                            ReviewerName = "Test",
                            Body = "Test"
                         }
                    );
                    context.SaveChanges();
                }

            }
        }
    }
}
