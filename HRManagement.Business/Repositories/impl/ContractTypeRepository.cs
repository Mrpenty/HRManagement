using HRManagement.Business.dtos.page;
using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories.impl;

public class ContractTypeRepository : IContractTypeRepository
{
    private readonly IRepositoryAsync<ContractType> _contractTypeRepository;
    public ContractTypeRepository(IRepositoryAsync<ContractType> contractTypeRepository)
    {
        _contractTypeRepository = contractTypeRepository;
    }

    public async Task AddAsync(ContractType entity)
    {
        await _contractTypeRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _contractTypeRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ContractType>> GetAsync()
    {
        return await _contractTypeRepository.GetAsync();
    }

    public async Task<ContractType> GetByIdAsync(int id)
    {
        return await _contractTypeRepository.GetByIdAsync(id);
    }

    public IQueryable<ContractType> GetQueryable()
    {
        return _contractTypeRepository.GetQueryable();
    }


    public async Task UpdateAsync(ContractType entity)
    {
        await _contractTypeRepository.UpdateAsync(entity);
    }
}