namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Castle.Core.Internal;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
    using System.Runtime.ExceptionServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //var command = Console.ReadLine();                           // 2ex.
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            Console.WriteLine(GetMostRecentBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command) // 2
        {
            if (!Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
                return $"{command} is not a valid command.";

            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => new
                {
                    x.Title
                }).OrderBy(x => x.Title)
                .ToList();

            return String.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetGoldenBooks(BookShopContext context) // 3
        {
            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => new
                {
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();

            return String.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetBooksByPrice(BookShopContext context) // 4
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Price,
                    x.Title
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            return String.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:f2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year) // 5
        {
            var books = context.Books
                .Select(x => new
                {
                    x.BookId,
                    x.ReleaseDate,
                    x.Title
                })
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId);

            return String.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetBooksByCategory(BookShopContext context, string input) // 6
        {
            string[] categories = input.Split(null).Select(x => x.ToLower()).ToArray();
            StringBuilder res = new StringBuilder();
            List<string> allBooks = new List<string>();

            for (int i = 0; i < categories.Length; i++)
            {
                var books = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .Select(x => new
                {
                    x.Title,
                    categoryName = x.BookCategories.First().Category.Name.ToLower()
                })
                .Where(x => x.categoryName == categories[i])
                .OrderBy(x => x.Title)
                .AsEnumerable();

                foreach (var book in books)
                {
                    if(categories.Contains(book.categoryName))
                        allBooks.Add(book.Title);
                }
            }
            allBooks.Sort();
            res.Append(String.Join(Environment.NewLine, allBooks)).Append(Environment.NewLine);

            return res.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date) // 7
        {

            var books = context.Books
                .Select(x => new
                {
                    x.ReleaseDate,
                    x.Title,
                    x.EditionType,
                    x.Price
                }).
                Where(x => x.ReleaseDate.Value.Date < DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture))
                .OrderByDescending(x => x.ReleaseDate);
            return String.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price}"));
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input) // 8
        {
            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            return String.Join(Environment.NewLine, authors.Select(x => $"{x.FirstName} {x.LastName}"));
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input) // 9
        {
            var books = context.Books
                .Select(x => new
                {
                    x.Title
                })
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .AsEnumerable();


            return String.Join(Environment.NewLine, books.Select(x => $"{x.Title}"));
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)  // 10
        {
            var booksAuthors = context.Books
                .Include(x => x.Author)
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    x.Author.FirstName,
                    x.Author.LastName
                })
                .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId);

            return String.Join(Environment.NewLine, booksAuthors.Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck) // 11
        {
            var books = context.Books
                .Select(x => new
                {
                    x.Title
                })
                .Where(x => x.Title.Length > lengthCheck)
                .AsEnumerable();

            return books.Count();
        }
        public static string CountCopiesByAuthor(BookShopContext context) // 12
        {
            var bookCopiesByAuthor = context.Authors
                .Select(x => new
                {
                    AuthorFullName = $"{x.FirstName} {x.LastName}",
                    copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.copies);

            return String.Join(Environment.NewLine, bookCopiesByAuthor.Select(x => $"{x.AuthorFullName} - {x.copies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context) // 13
        {
            var profitByCategories = context.Categories
                .Include(x => x.CategoryBooks)
                .Select(x => new
                {
                    x.Name,
                    totalSum = x.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
                })
                .OrderByDescending(x => x.totalSum)
                .ThenBy(x => x.Name); 

            return String.Join(Environment.NewLine, profitByCategories.Select(x => $"{x.Name} ${x.totalSum:f2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context) // 14
        {

            var mostRecentByCategories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    mostRecentBook = x.CategoryBooks.OrderByDescending(x => x.Book.ReleaseDate).Take(3).Select(x => new
                    {
                        title = x.Book.Title,
                        date = x.Book.ReleaseDate.Value.Year
                    })
                    .OrderBy(x => x.title)
                });
            StringBuilder res = new StringBuilder();
            foreach (var book in mostRecentByCategories)
            {
                res.AppendLine($"--{book.Name}");
                foreach (var item in book.mostRecentBook)
                {
                    res.AppendLine($"{item.title} ({item.date})");
                }
            }
            return res.ToString();
        }
    }
}


