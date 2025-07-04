﻿using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRManagement.Business.Repositories.impl;

public class LeaveRequestRepository : ILeaveRequestRepository
{
    private readonly IRepositoryAsync<LeaveRequest> _leaveRequestRepository;
    private readonly HRManagementDbContext _context;
    public LeaveRequestRepository(IRepositoryAsync<LeaveRequest> leaveRequestRepository, HRManagementDbContext context)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _context = context;
    }
    public async Task AddAsync(LeaveRequest entity)
    {
        await _leaveRequestRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _leaveRequestRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LeaveRequest>> GetAsync()
    {
        return await _leaveRequestRepository.GetAsync();
    }

    public async Task<LeaveRequest> GetByIdAsync(int id)
    {
        return await _leaveRequestRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(LeaveRequest entity)
    {
        await _leaveRequestRepository.UpdateAsync(entity);
    }

    //Trí làm: Lấy các đơn xin nghỉ tháng này
    public async Task<List<LeaveRequest>> GetMyLeavesInMonthAsync(int userId, int month, int year)
    {
        var allowedStatuses = new[] { "Approved", "Pending" };
        return await _context.LeaveRequests
            .Where(lr => lr.UserID == userId
                         && allowedStatuses.Contains(lr.Status)
                         && lr.StartDate.Month == month
                         && lr.StartDate.Year == year)
            .ToListAsync();
    }
    //Trí làm: Lấy các đơn xin nghỉ năm nay
    public async Task<List<LeaveRequest>> GetMyLeavesInYearAsync(int userId, int year)
    {
        return await _context.LeaveRequests
            .Where(lr => lr.UserID == userId
            && lr.StartDate.Year == year).ToListAsync();
    }
    public async Task<IEnumerable<LeaveRequest>> GetAllWithUserAsync()
    {
        return await _context.LeaveRequests
            .Include(lr => lr.User)
            .ToListAsync();
    } 
}