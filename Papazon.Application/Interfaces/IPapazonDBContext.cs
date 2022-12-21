using Microsoft.EntityFrameworkCore;
using Papazon.Domain;

namespace Papazon.Application.Interfaces
{
    public interface IPapazonDBContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}