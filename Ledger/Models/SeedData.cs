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
                             ID = 1,
                             FirstName = "Stephen",
                             LastName = "King"
                         },

                         new AuthorClass
                         {
                             ID = 2,
                             FirstName = "Joanne",
                             LastName = "Rowling"
                         },

                         new AuthorClass
                         {
                             ID = 3, 
                             FirstName = "Ernest",
                             LastName = "Hemingway"
                         },

                         new AuthorClass
                         {
                             ID = 4, 
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
                             ID = 1,
                             AuthorID = 1,
                             Title = "The Shining",
                             ISBN = "978-03-85121-67-5",
                             PublishDate = new DateTime(1977, 1, 28)
                         },

                         new BookClass
                         {
                             ID = 2,
                             AuthorID = 2,
                             Title = "Harry Potter and the Sorcerer's Stone",
                             ISBN = "978-04-39708-18-0",
                             PublishDate = new DateTime(1998, 9, 1)
                         },

                         new BookClass
                         {
                             ID = 3,
                             AuthorID = 3,
                             Title = "For Whom the Bell Tolls",
                             ISBN = "978-06-84803-35-7",
                             PublishDate = new DateTime(1940, 10, 21),
                         },

                         new BookClass
                         {
                             ID = 4,
                             AuthorID = 4,
                             Title = "Adventures of Huckleberry Finn",
                             ISBN = "978-15-03214-95-8",
                             PublishDate = new DateTime(1884, 12, 10)
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
                            ID = 1,
                            BookID = 1,
                            ReviewerName = "Test",
                            Body = "Test"
                         },

                         new ReviewClass
                         {
                            ID = 2,
                            BookID = 2,
                            ReviewerName = "Test",
                            Body = "Test"
                         },

                         new ReviewClass
                         {
                            ID = 3,
                            BookID = 3,
                            ReviewerName = "Test",
                            Body = "Test"
                         },

                         new ReviewClass
                         {
                            ID = 4,
                            BookID = 4,
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
