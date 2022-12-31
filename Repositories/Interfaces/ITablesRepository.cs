using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface ITablesRepository
{
    Table? Update(Table newTable);
    
    IEnumerable<Table> GetAll();
}