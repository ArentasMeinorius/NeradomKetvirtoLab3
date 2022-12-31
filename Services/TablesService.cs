using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Repositories;

namespace NeradomKetvirtoLab3.Services;

public class TablesService : ITablesService
{
    private readonly ITablesRepository _tablesRepository;
    
    public TablesService(ITablesRepository tablesRepository)
    {
        _tablesRepository = tablesRepository;
    }

    public IEnumerable<Table> GetAllTables()
        => _tablesRepository.GetAll();

    public Table? Update(Table newTable)
        => _tablesRepository.Update(newTable);
}