using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories;

public interface IPaySlipRepository : IRepositoryAsync<Payslip>
{
    Task<Payslip?> GetByIdWithDetailsAsync(int id);
}