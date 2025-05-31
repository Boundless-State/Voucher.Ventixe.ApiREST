# 🎫 Voucher.Ventixe.ApiREST

Detta är ett REST-baserat mikrotjänst-API för att hantera **e-vouchers** kopplade till bokningar i ett eventhanteringssystem.

API:t erbjuder full CRUD-funktionalitet samt är integrerat med Swagger och ett separat testprojekt för verifiering.

---

## 📦 Teknologier

- .NET 9.0 (preview)
- ASP.NET Core Web API
- Entity Framework Core med LocalDb
- Swagger (OpenAPI)
- xUnit & Microsoft.AspNetCore.Mvc.Testing (integrationstester)

---

## 📁 Projektstruktur

```
/solution-root
│
├── Voucher.Ventixe.ApiREST/           # Själva REST-API:t
│   ├── Controllers/
│   ├── Services/
│   ├── Repositories/
│   ├── Models/
│   ├── Data/
│   ├── Entities/
│   ├── Program.cs
│   └── appsettings.json
│
├── VoucherApi_Test/                   # Testprojekt med xUnit
│   ├── EVoucherControllerTests.cs
│   └── VoucherApi_Test.csproj
```

---

## 🚀 Kom igång

### 1. Klona och gå till mappen:
```bash
git clone <din-repo-länk>
cd Voucher.Ventixe.ApiREST
```

### 2. Kör API:t lokalt:
```bash
dotnet run
```

### 3. Swagger öppnas här:
```
https://localhost:7199/swagger
```

---

## ⚙️ Databas

API:t använder `LocalDb` och databasen kopplas via `appsettings.json`.

```json
"ConnectionStrings": {
  "EVoucherDb": "Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\...\EVoucherDb.mdf;Integrated Security=True;Connect Timeout=30"
}
```

---

## 🔐 Säkerhet & konfiguration

- CORS är aktiverat globalt
- Swagger finns i `Program.cs` och visas automatiskt vid start
- Controllers är dokumenterade med `<summary>`-kommentarer

---

## 🧪 Tester – VoucherApi_Test

Projektet `VoucherApi_Test` innehåller integrationstester med `WebApplicationFactory<Program>`. Det verifierar API:ts externa HTTP-beteende.

### 🔍 Tester som ingår

| Test | Funktion |
|------|----------|
| `CanCreateVoucher_Returns201` | Skapar en ny e-voucher |
| `GetMissingVoucher_Returns404` | Returnerar 404 om ID inte finns |
| `CanDeleteVoucher_IfExists` | Skapar och raderar en voucher |

### ▶️ Så kör du testerna

```bash
dotnet clean
dotnet build
dotnet test --no-build
```

> ✅ Kör från solution-root. `--no-build` krävs ibland för att undvika `testhost.deps.json`-problem.

---

## 📌 Design & struktur

- Följer **SOLID-principer**
- Separation mellan controller, service och repository
- DTOs används för externt dataflöde
- Swagger genereras automatiskt
- Kod redo för microservices och molnpublicering

---

## 📬 Exempel – Skapa en e-voucher

```
POST /api/evoucher
Content-Type: application/json

{
  "bookingId": "abc-123",
  "holderName": "Timmy Tester",
  "ticketCategory": "VIP",
  "seatNumber": "A10",
  "gate": "3C",
  "eventDate": "2025-06-01",
  "location": "Eventhallen"
}
```

Svar: `201 Created` + ny voucher med genererat ID och barcode.

---

## 📌 Kommande förbättringar

- ☑️ Paging och filtrering på `GET`
- ☑️ Koppling till Booking-mikrotjänst
- ☐ E-postutskick av e-voucher
- ☐ QR-kodsgenerering i PDF

---

## 👤 Kontakt

Detta projekt är en del av ett grupparbete vid [din skola].  
Delarna är publicerade i separata GitHub-repos enligt instruktion.