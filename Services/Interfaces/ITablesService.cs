using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface ITablesService
{
    public IEnumerable<Table> GetAllTables();

    public Table? Update(Table newTable);
}