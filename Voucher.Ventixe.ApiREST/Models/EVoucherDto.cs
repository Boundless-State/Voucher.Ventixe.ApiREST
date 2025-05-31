namespace Voucher.Ventixe.ApiREST.Models;
public class EVoucherDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? BookingId { get; set; }
    public string? HolderName { get; set; }
    public string? TicketCategory { get; set; }
    public string? SeatNumber { get; set; }
    public string? Gate { get; set; }
    public DateTime EventDate { get; set; }
    public string? Location { get; set; }
    public string? Barcode { get; set; }
}

