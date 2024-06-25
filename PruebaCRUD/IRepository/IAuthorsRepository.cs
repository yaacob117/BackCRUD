

using PruebaCRUD.DTO;
using PruebaCRUD.Models;

namespace PruebaCRUD.IRepository
{
    public interface IAuthorsRepository
    {
        Task<Authors> AddAuthor(AuthorDTO authorDTO);
        Task UpdateAuthor(Authors authors);
        Task<Authors> DeleteAuthor(int AuthorID);
        ICollection<Authors> GetAllAuthors();
        //Task<Authors> GetAuthorById(int AuthorID, string? LastName);

    }
}
