using Microsoft.EntityFrameworkCore;
using Voucher.Ventixe.ApiREST.Data;
using Voucher.Ventixe.ApiREST.Entities;
using Voucher.Ventixe.ApiREST.Models;

namespace Voucher.Ventixe.ApiREST.Repositories;
public interface IEVoucherRepository
{
    Task<List<EVoucherEntity>> GetAllAsync();
    Task<EVoucherEntity?> GetByIdAsync(string id);
    Task<EVoucherEntity> CreateAsync(CreateEVoucherDto dto);
    Task<bool> UpdateAsync(string id, UpdateEVoucherDto dto);
    Task<bool> DeleteAsync(string id);
}
public class EVoucherRepository : IEVoucherRepository
{
    private readonly EVoucherDbContext _context;

    public EVoucherRepository(EVoucherDbContext context)
    {
        _context = context;
    }

    public async Task<List<EVoucherEntity>> GetAllAsync()
        => await _context.Vouchers.ToListAsync();

    public async Task<EVoucherEntity?> GetByIdAsync(string id)
        => await _context.Vouchers.FindAsync(id);

    public async Task<EVoucherEntity> CreateAsync(CreateEVoucherDto dto)
    {
        var entity = new EVoucherEntity
        {
            Id = Guid.NewGuid().ToString(),
            BookingId = dto.BookingId,
            HolderName = dto.HolderName,
            TicketCategory = dto.TicketCategory,
            SeatNumber = dto.SeatNumber,
            Gate = dto.Gate,
            EventDate = dto.EventDate.Date,
            Location = dto.Location,
            Barcode = Guid.NewGuid().ToString("N")[..10]
        };

        _context.Vouchers.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(string id, UpdateEVoucherDto dto)
    {
        var entity = await _context.Vouchers.FindAsync(id);
        if (entity == null) return false;

        entity.HolderName = dto.HolderName;
        entity.TicketCategory = dto.TicketCategory;
        entity.SeatNumber = dto.SeatNumber;
        entity.Gate = dto.Gate;
        entity.EventDate = dto.EventDate.Date;
        entity.Location = dto.Location;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var entity = await _context.Vouchers.FindAsync(id);
        if (entity == null) return false;

        _context.Vouchers.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
