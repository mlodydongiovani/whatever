using Newtonsoft.Json;
using Promise.Application.Books;
using Promise.Books.Models;
using Promise.Clients.Authentication.Common;
using System.Text;

namespace Promise.Clients.Books;

public class BooksClient(HttpClient client) : ClientBase(client), IBooksClient
{
    public async Task<List<Book>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync("/api/books");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<Book>>(content)!;
    }

    public async Task PostBookAsync(Book book)
    {
        var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/api/books", content);

        response.EnsureSuccessStatusCode();
    }
}
