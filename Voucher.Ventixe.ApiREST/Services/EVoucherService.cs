using Voucher.Ventixe.ApiREST.Models;
using Voucher.Ventixe.ApiREST.Repositories;

namespace Voucher.Ventixe.ApiREST.Services;

public class EVoucherService
{
    private readonly IEVoucherRepository _repo;

    public EVoucherService(EVoucherRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<EVoucherDto>> GetAllAsync()
    {
        var result = await _repo.GetAllAsync();
        return result.Select(MapToDto).ToList();
    }

    public async Task<EVoucherDto?> GetByIdAsync(string id)
    {
        var entity = await _repo.GetByIdAsync(id);
        return entity is null ? null : MapToDto(entity);
    }

    public async Task<EVoucherDto> CreateAsync(CreateEVoucherDto dto)
    {
        var entity = await _repo.CreateAsync(dto);
        return MapToDto(entity);
    }

    public Task<bool> UpdateAsync(string id, UpdateEVoucherDto dto)
        => _repo.UpdateAsync(id, dto);

    public Task<bool> DeleteAsync(string id)
        => _repo.DeleteAsync(id);

    private static EVoucherDto MapToDto(Entities.EVoucherEntity entity) => new()
    {
        Id = entity.Id,
        BookingId = entity.BookingId,
        HolderName = entity.HolderName,
        TicketCategory = entity.TicketCategory,
        SeatNumber = entity.SeatNumber,
        Gate = entity.Gate,
        EventDate = entity.EventDate,
        Location = entity.Location,
        Barcode = entity.Barcode
    };
}
