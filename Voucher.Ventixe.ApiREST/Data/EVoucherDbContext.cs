using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Voucher.Ventixe.ApiREST.Entities;

namespace Voucher.Ventixe.ApiREST.Data;

public class EVoucherDbContext : DbContext
{
    public EVoucherDbContext(DbContextOptions<EVoucherDbContext> options) : base(options) { }

    public DbSet<EVoucherEntity> Vouchers => Set<EVoucherEntity>();
}
