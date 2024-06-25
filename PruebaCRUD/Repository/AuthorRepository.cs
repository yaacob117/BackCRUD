using Microsoft.EntityFrameworkCore;
using PruebaCRUD.Contexts;
using PruebaCRUD.DTO;
using PruebaCRUD.IRepository;
using PruebaCRUD.Models;

namespace PruebaCRUD.Repository
{
    public class AuthorRepository : IAuthorsRepository
    {
        private readonly LocalDBContext _context;

        public AuthorRepository(LocalDBContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<Authors> AddAuthor(AuthorDTO authorDTO)
        {
            try
            {
                var newAuthor = new Authors
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    BirthDate = authorDTO.BirthDate
                };

                _context.Authors.Add(newAuthor);
                await _context.SaveChangesAsync();
                return newAuthor;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception();
                throw exception;
            }
        }



        public async Task<Authors> DeleteAuthor(int AuthorID)
        {
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorID == AuthorID);

                if (author == null)
                {

                    throw new InvalidOperationException("Author not found");
                }
                else
                {
                     _context.Authors.Remove(author);
                     await _context.SaveChangesAsync();
                     return author; // Devuelve el autor eliminado
                }
               
                    
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting author: {ex.Message}", ex);
            }
        }





        public ICollection<Authors> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }



        //public async Task<Authors> GetAuthorById(int AuthorID, string? LastName)
        //{
        //    try
        //    {
        //        if (LastName != null)
        //        {
        //            return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorID == AuthorID && a.LastName == LastName);
        //        }
        //        else
        //        {
        //            return await _context.Authors.FindAsync(AuthorID);
        //        }
        //    }
        //    catch
        //    {
        //        Exception exception = new Exception();
        //        throw exception;
        //    }
        //}

        public async Task UpdateAuthor(Authors authors)
        {
            var authorInfo = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorID == authors.AuthorID);
            
            try
            {
                if (authorInfo != null) {

                    authorInfo.LastName = authors.LastName;
                    authorInfo.FirstName = authors.FirstName;
                    authorInfo.BirthDate = authors.BirthDate;

                    await _context.SaveChangesAsync();
                }
           }

            catch (Exception ex)
            {
                Exception exception = new Exception();
                throw exception;
            }
        }


        //Task<Authors> IAuthorsRepository.AddAuthor(string FirstName, string LastName, DateTime BirthDate)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Authors> IAuthorsRepository.DeleteAuthor(int AuthorID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
