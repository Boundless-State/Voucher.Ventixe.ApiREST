
using Microsoft.EntityFrameworkCore;
using Voucher.Ventixe.ApiREST.Data;
using Voucher.Ventixe.ApiREST.Repositories;
using Voucher.Ventixe.ApiREST.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EVoucherDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EVoucherDb")));

builder.Services.AddScoped<EVoucherRepository>();
builder.Services.AddScoped<EVoucherService>();
builder.Services.AddScoped<IEVoucherRepository, EVoucherRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});
app.UseAuthorization();
app.MapControllers();

app.Run();
public partial class Program { }