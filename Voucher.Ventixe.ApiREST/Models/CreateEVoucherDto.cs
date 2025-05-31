namespace Voucher.Ventixe.ApiREST.Models;
public class CreateEVoucherDto
{
    public string BookingId { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string TicketCategory { get; set; } = string.Empty;
    public string SeatNumber { get; set; } = string.Empty;
    public string Gate { get; set; } = string.Empty;
    public DateTime EventDate { get; set; } = DateTime.UtcNow;
    public string Location { get; set; } = string.Empty;
}

