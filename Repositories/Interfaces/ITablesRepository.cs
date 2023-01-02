using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface ITablesRepository
{
    Task<Table?> Update(Table newTable);
    
    Task<IEnumerable<Table>> GetAll();
}