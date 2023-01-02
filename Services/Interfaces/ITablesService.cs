using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface ITablesService
{
    Task<IEnumerable<Table>> GetAllTables();

    Task<Table?> Update(Table newTable);
}