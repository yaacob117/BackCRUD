using PruebaCRUD.Models;
namespace PruebaCRUD.IRepository
{
    public interface IBooksRepository
    {
        ICollection<Book> GetAllBooks();
        ICollection<Book> GetBookById(int BookID, string? Title);
        Task <string> AddBook(string Title, int AuthorID, DateTime PublicationYear, string Genre);
        Task ModifyBook(string Title,  DateTime? PublicationYear, string? Genre);
        Task DeleteBook(int BookID);
    }
}
