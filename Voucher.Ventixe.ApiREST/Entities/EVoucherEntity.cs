namespace Voucher.Ventixe.ApiREST.Entities;

public class EVoucherEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string BookingId { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string TicketCategory { get; set; } = string.Empty;
    public string SeatNumber { get; set; } = string.Empty;
    public string Gate { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Barcode { get; set; } = Guid.NewGuid().ToString("N")[..10];
}
