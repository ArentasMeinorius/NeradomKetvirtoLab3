using Microsoft.EntityFrameworkCore;
using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public class TablesRepository : ITablesRepository
{
    public TablesRepository()
    {
        using var context = new ProjectDbContext();
        
        var tables = new List<Table>
        {
            new()
            {
                Id = Guid.NewGuid(),
                SeatCount = 4,
                IsOccupied = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                SeatCount = 6,
                IsOccupied = false
            }
        };
        
        context.Tables.AddRange(tables);
        context.SaveChanges();
    }
    
    public async Task<Table?> Update(Table newTable)
    {
        await using var context = new ProjectDbContext();
        var table = await context.Tables.FirstOrDefaultAsync(table => table.Id == newTable.Id);
        if (table is null)
            return null;
        
        table.SeatCount = newTable.SeatCount;
        table.IsOccupied = newTable.IsOccupied;
        
        context.Tables.Update(table);
        await context.SaveChangesAsync();
        
        return table;
    }

    public async Task<IEnumerable<Table>> GetAll()
    {
        await using var context = new ProjectDbContext();
        return await context.Tables.ToListAsync();
    }
}