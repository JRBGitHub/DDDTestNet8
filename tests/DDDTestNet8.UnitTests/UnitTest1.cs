using DDDTestNet8.Domain;
using DDDTestNet8.Application;
using DDDTestNet8.Infrastructure;
namespace DDDTestNet8.UnitTests;

public class AcumuladoDivisaServiceTests
{
    private List<AcumuladoDivisa> _db;
    private AcumuladoDivisaInMemoryRepository _repo;
    private AcumuladoDivisaService _service;

    [SetUp]
    public void Setup()
    {
        _db = new List<AcumuladoDivisa>
        {
            new AcumuladoDivisa { IdHost = 1, Canal = "WEB1", AcumuladoDiario = 100, AcumuladoSemanal = 500, AcumuladoMensual = 2000 },
            new AcumuladoDivisa { IdHost = 1, Canal = "APP2", AcumuladoDiario = 50, AcumuladoSemanal = 200, AcumuladoMensual = 800 },
            new AcumuladoDivisa { IdHost = 2, Canal = "WEB1", AcumuladoDiario = 20, AcumuladoSemanal = 100, AcumuladoMensual = 400 },
        };
        _repo = new AcumuladoDivisaInMemoryRepository(_db);
        _service = new AcumuladoDivisaService(_repo);
    }

    [Test]
    public void GetAcumulados_ReturnsAllChannels_WhenOnlyIdHostProvided()
    {
        var result = _service.GetAcumulados(1);
        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GetAcumulados_ReturnsFilteredByChannel_WhenChannelProvided()
    {
        var result = _service.GetAcumulados(1, "WEB1");
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Canal, Is.EqualTo("WEB1"));
    }

    [Test]
    public void GetAcumulados_ReturnsEmpty_WhenNoMatch()
    {
        var result = _service.GetAcumulados(3);
        Assert.That(result, Is.Empty);
    }
}
