using PruebaCRUD.Models;

namespace PruebaCRUD.IRepository
{
    public interface ILoanRepository
    {
        ICollection<Loan> GetAllLoans();
        ICollection<Loan> GetLoanById(int LoanID, int? BookID, int? UserID);
        Task AddLoan(int BookID, int UserID);
        Task ModifyLoan(DateTime ReturnDate);
        Task ValidateLoan();

    }
}
