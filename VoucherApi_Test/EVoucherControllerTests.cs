using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Voucher.Ventixe.ApiREST.Models;

namespace VoucherApi_Test;

public class EVoucherControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public EVoucherControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CanCreateVoucher_Returns201()
    {
        // Arrange
        var dto = new CreateEVoucherDto
        {
            BookingId = "booking-123",
            HolderName = "Test User",
            TicketCategory = "VIP",
            SeatNumber = "A1",
            Gate = "2B",
            EventDate = DateTime.UtcNow,
            Location = "Arena X"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/evoucher", dto);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GetMissingVoucher_Returns404()
    {
        // Arrange
        var nonExistentId = "does-not-exist";

        // Act
        var response = await _client.GetAsync($"/api/evoucher/{nonExistentId}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CanDeleteVoucher_IfExists()
    {
        // Arrange: först skapa en voucher
        var dto = new CreateEVoucherDto
        {
            BookingId = "delete-456",
            HolderName = "Delete Me",
            TicketCategory = "Standard",
            SeatNumber = "C4",
            Gate = "5A",
            EventDate = DateTime.UtcNow,
            Location = "Stadium Y"
        };

        var createResponse = await _client.PostAsJsonAsync("/api/evoucher", dto);
        var created = await createResponse.Content.ReadFromJsonAsync<EVoucherDto>();

        // Act: försök ta bort vouchern
        var deleteResponse = await _client.DeleteAsync($"/api/evoucher/{created!.Id}");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }
}

