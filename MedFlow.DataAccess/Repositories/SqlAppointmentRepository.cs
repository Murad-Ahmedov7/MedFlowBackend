
using DataAccess.Internals;
using Domain.Entities.Appointments;
using Domain.Entities.DoctorSchedules;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class SqlAppointmentRepository : BaseSqlRepository<Appointment>
{
    public SqlAppointmentRepository(MedDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Appointment?> GetAppointmentByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Appointments
            .Include(x => x.Doctor)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Appointment>> GetAllAppointmentsAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Appointments
            .Include(x => x.Doctor)
            .ThenInclude(x => x.User)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> HasAppointmentOverlapAsync(Guid doctorId, DateOnly appointmentDate, TimeOnly startTime, TimeOnly endTime)
    {
        return await DbContext.Appointments
            .AnyAsync(x => x.DoctorId == doctorId && x.AppointmentDate == appointmentDate && x.StartTime < endTime && x.EndTime > startTime);
    }

    public async Task<int> GetMaxQueueNumberAsync(Guid doctorId, DateOnly appointmentDate, CancellationToken cancellationToken = default)
    {
        return await DbContext.Appointments
            .Where(x => x.DoctorId == doctorId && x.AppointmentDate == appointmentDate)
            .Select(x => x.QueueNumber)
            .DefaultIfEmpty()
            .MaxAsync(cancellationToken);
    }
}