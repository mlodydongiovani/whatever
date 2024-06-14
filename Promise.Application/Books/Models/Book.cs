namespace Promise.Books.Models;

public record Book(int Id, string Title, decimal Price, int Bookstand, int Shelf, IEnumerable<Author> Authors);

