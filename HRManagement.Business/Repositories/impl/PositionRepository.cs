using HRManagement.Data.Entity;

namespace HRManagement.Business.Repositories.impl;

public class PositionRepository : IPositionRepository
{
    private readonly IRepositoryAsync<Position> _positionRepository;
    public PositionRepository(IRepositoryAsync<Position> positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task AddAsync(Position entity)
    {
        await _positionRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _positionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Position>> GetAsync()
    {
        return await _positionRepository.GetAsync();
    }

    public async Task<Position> GetByIdAsync(int id)
    {
        return await _positionRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Position entity)
    {
        await _positionRepository.UpdateAsync(entity);
    }
}