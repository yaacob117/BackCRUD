using PruebaCRUD.Models;
namespace PruebaCRUD.IRepository
{
    public interface IUsersRepository
    {
        ICollection<User> GetAllUsers();
        ICollection<User> GetUserById(int UserID, string? LastName);
        Task AddUser(string FirstName, string LastName, string? Email);
        Task ModifyUser(string FirstName, string LastName, string? Email);
        Task DeleteUser(int UserID);

    }
}
