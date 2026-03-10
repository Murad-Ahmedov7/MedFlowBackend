
using DataAccess.Internals;
using Domain.Entities.DoctorSchedules;
using Microsoft.EntityFrameworkCore;
using DayOfWeek = Domain.Entities.DoctorSchedules.Enums.DayOfWeek;


namespace DataAccess.Repositories;
public sealed class SqlDoctorScheduleRepository : BaseSqlRepository<DoctorSchedule>
{
    public SqlDoctorScheduleRepository(MedDbContext dbContext) : base(dbContext)
    {


    }

    public async Task<List<DayOfWeek>> GetDayOfWeeksByDoctorIdAsync(Guid DoctorId, CancellationToken cancellationToken = default)
    {
        return await DbContext.DoctorSchedules
            .Where(d => d.DoctorId == DoctorId)
            .Select(d => d.DayOfWeek)
            .ToListAsync(cancellationToken);
    }

}

