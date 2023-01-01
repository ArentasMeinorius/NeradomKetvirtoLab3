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
    
    public Table? Update(Table newTable)
    {
        using var context = new ProjectDbContext();
        var table = context.Tables.FirstOrDefault(table => table.Id == newTable.Id);
        if (table is null)
            return null;
        
        table.SeatCount = newTable.SeatCount;
        table.IsOccupied = newTable.IsOccupied;
        
        context.Tables.Update(table);
        context.SaveChanges();
        
        return table;
    }

    public IEnumerable<Table> GetAll()
    {
        using var context = new ProjectDbContext();
        return context.Tables;
    }
}