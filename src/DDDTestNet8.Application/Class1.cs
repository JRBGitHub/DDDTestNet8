using DDDTestNet8.Domain;
using DDDTestNet8.Infrastructure;
namespace DDDTestNet8.Application;

public interface IAcumuladoDivisaService
{
    IEnumerable<AcumuladoDivisa> GetAcumulados(int idHost, string? canal = null);
}

public class AcumuladoDivisaService : IAcumuladoDivisaService
{
    private readonly IAcumuladoDivisaRepository _repo;

    public AcumuladoDivisaService(IAcumuladoDivisaRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<AcumuladoDivisa> GetAcumulados(int idHost, string? canal = null)
    {
        if (!string.IsNullOrEmpty(canal))
            return _repo.GetByIdHostAndCanal(idHost, canal);
        return _repo.GetByIdHost(idHost);
    }
}
