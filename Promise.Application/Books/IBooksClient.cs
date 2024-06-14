using Promise.Books.Models;

namespace Promise.Application.Books;

public interface IBooksClient
{
    Task<List<Book>> GetBooksAsync();
    Task PostBookAsync(Book book);
}
