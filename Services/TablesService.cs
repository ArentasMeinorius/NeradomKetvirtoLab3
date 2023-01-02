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

    public async Task<IEnumerable<Table>> GetAllTables()
        => await _tablesRepository.GetAll();

    public async Task<Table?> Update(Table newTable)
        => await _tablesRepository.Update(newTable);
}