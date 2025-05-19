using DDDTestNet8.Domain;
namespace DDDTestNet8.Infrastructure;

// Simulación de un repositorio de acumulados (en memoria)
public interface IAcumuladoDivisaRepository
{
    IEnumerable<AcumuladoDivisa> GetByIdHost(int idHost);
    IEnumerable<AcumuladoDivisa> GetByIdHostAndCanal(int idHost, string canal);
}

public class AcumuladoDivisaInMemoryRepository : IAcumuladoDivisaRepository
{
    private readonly List<AcumuladoDivisa> _db;

    public AcumuladoDivisaInMemoryRepository(List<AcumuladoDivisa> db)
    {
        _db = db;
    }

    public IEnumerable<AcumuladoDivisa> GetByIdHost(int idHost)
        => _db.Where(x => x.IdHost == idHost);

    public IEnumerable<AcumuladoDivisa> GetByIdHostAndCanal(int idHost, string canal)
        => _db.Where(x => x.IdHost == idHost && x.Canal == canal);
}
