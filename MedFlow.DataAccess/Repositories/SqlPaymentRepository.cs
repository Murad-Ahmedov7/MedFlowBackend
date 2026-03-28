
using DataAccess.Internals;
using Domain.Entities.Billing.Payments;

namespace DataAccess.Repositories;

public sealed class SqlPaymentRepository : BaseSqlRepository<Payment>
{
    public SqlPaymentRepository(MedDbContext dbContext) : base(dbContext)
    {

    }
}
