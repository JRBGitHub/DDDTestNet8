using System.Collections.Generic;
using System.Linq;
using DDDTestNet8.Domain;
using DDDTestNet8.Application;
using DDDTestNet8.Infrastructure;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace DDDTestNet8.UnitTests
{
    [Binding]
    public class ConsultaAcumuladosSteps
    {
        private List<AcumuladoDivisa> _db;
        private AcumuladoDivisaInMemoryRepository _repo;
        private AcumuladoDivisaService _service;
        private IEnumerable<AcumuladoDivisa> _result;

        [Given("existe un cliente con idhost (\\d+) y canales \"(.*)\"")]
        public void GivenExisteUnClienteConIdhostYCanales(int idhost, string canales)
        {
            var canalesArr = canales.Split(new[] { " y " }, System.StringSplitOptions.None);
            _db = new List<AcumuladoDivisa>();
            foreach (var canal in canalesArr)
            {
                _db.Add(new AcumuladoDivisa { IdHost = idhost, Canal = canal.Trim(' ', '"'), AcumuladoDiario = 100, AcumuladoSemanal = 500, AcumuladoMensual = 2000 });
            }
            _repo = new AcumuladoDivisaInMemoryRepository(_db);
            _service = new AcumuladoDivisaService(_repo);
        }

        [Given(@"no existe un cliente con idhost (\d+)")]
        public void GivenNoExisteUnClienteConIdhost(int idhost)
        {
            _db = new List<AcumuladoDivisa>();
            _repo = new AcumuladoDivisaInMemoryRepository(_db);
            _service = new AcumuladoDivisaService(_repo);
        }

        [When(@"consulto los acumulados para el cliente con idhost (\d+)")]
        public void WhenConsultoLosAcumuladosParaElClienteConIdhost(int idhost)
        {
            _result = _service.GetAcumulados(idhost);
        }

        [When("consulto los acumulados para el cliente con idhost (\\d+) y canal \"(.*)\"")]
        public void WhenConsultoLosAcumuladosParaElClienteConIdhostYCanal(int idhost, string canal)
        {
            _result = _service.GetAcumulados(idhost, canal);
        }

        [Then(@"obtengo (\d+) acumulados")]
        public void ThenObtengoNAcumulados(int cantidad)
        {
            Assert.That(_result.Count(), Is.EqualTo(cantidad));
        }

        [Then("obtengo 1 acumulado con canal \"(.*)\"")]
        public void ThenObtengoUnAcumuladoConCanal(string canal)
        {
            Assert.That(_result.Count(), Is.EqualTo(1));
            Assert.That(_result.First().Canal, Is.EqualTo(canal));
        }
    }
}
