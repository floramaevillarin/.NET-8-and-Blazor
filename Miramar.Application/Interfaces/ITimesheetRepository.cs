using Miramar.Domain.Entities;

namespace Miramar.Application.Interfaces
{
    public interface ITimesheetRepository
    {
        Task AddAsync(Timesheet timesheet);
        Task<List<Timesheet>> GetAllAsync();
        Task<Timesheet?> GetByIdAsync(int id);
        Task UpdateAsync(Timesheet timesheet);
        Task DeleteByIdAsync(int id);
    }
}
