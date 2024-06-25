using Microsoft.EntityFrameworkCore;
using PruebaCRUD.Contexts;
using PruebaCRUD.IRepository;
using PruebaCRUD.Models;

namespace PruebaCRUD.Repository
{
    public class BookRepository : IBooksRepository
    {
        private readonly LocalDBContext _context;

        public BookRepository(LocalDBContext dbContext)
        {
            _context = dbContext;
        }



        public async Task<string> AddBook(string Title, int AuthorID, DateTime PublicationYear, string Genre)
        {
            try
            {
                var book = new Book { Title = Title, AuthorID = AuthorID, PublicationYear = PublicationYear, Genre = Genre };
                {
                    book.Title = Title;
                    book.AuthorID = AuthorID;
                    book.PublicationYear = PublicationYear;
                    book.Genre = Genre;
                };
                _context.Book.Add(book);
                await _context.SaveChangesAsync();
                return "Libro agregado exitosamente";

            }

            catch (Exception ex)
            {
                return $"Ocurrio un error al quere agregar un nuevo libro, intentalo de nuevo por favor";
            }
        }

        public Task DeleteBook(int BookID)
        {
            throw new NotImplementedException();
        }

        //public Task DeleteBook(int BookID)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex) 
        //    {

        //    }
        //}

        public ICollection<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public ICollection<Book> GetBookById(int BookID, string? Title)
        {
            throw new NotImplementedException();
        }

        public Task ModifyBook(string Title, DateTime? PublicationYear, string? Genre)
        {
            throw new NotImplementedException();
        }
    }
}
