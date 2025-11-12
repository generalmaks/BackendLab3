using BackendLab3.Interfaces.Dto;
using BackendLab3.Models;
using BackendLab3.Services.Dto.Expense;

namespace BackendLab3.Interfaces.Services;

public interface IExpensesService
{
    Task<IEnumerable<Expense>> ListAsync();
    Task<Expense?> GetByIdAsync(int id, int userId);
    Task<int> CreateAsync(int userId, CreateExpenseDto dto);
    Task UpdateAsync(int id, UpdateCurrencyDto dto);
    Task DeleteAsync(int id);
}