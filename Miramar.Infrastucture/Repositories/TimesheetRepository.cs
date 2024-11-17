using Microsoft.EntityFrameworkCore;
using Miramar.Application.Interfaces;
using Miramar.Domain.Entities;
using Miramar.Infrastructure.Context;

namespace Miramar.Infrastructure.Repositories
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly MiramarDbContext context;
        public TimesheetRepository(IDbContextFactory<MiramarDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Timesheet timesheet)
        {
            context.Timesheets.Add(timesheet);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var timesheet = await GetByIdAsync(id);
            if (timesheet is not null)
            {
                context.Timesheets.Remove(timesheet);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Timesheet>> GetAllAsync()
        {
            var timesheets = await context.Timesheets.ToListAsync();
            return timesheets;
        }

        public async Task<Timesheet?> GetByIdAsync(int id)
        {
            var timesheet = await context.Timesheets.FirstOrDefaultAsync(x => x.Id == id);
            return timesheet;
        }

        public Task UpdateAsync(Timesheet timesheet)
        {
            context.Entry(timesheet).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }
    }
}
