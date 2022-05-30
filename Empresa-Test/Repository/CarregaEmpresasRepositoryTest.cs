using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Teste_Empresa.Domain;
using Teste_Empresa.Repository;
using Xunit;

namespace Empresa_Test.Repository
{
    public class CarregaEmpresasRepositoryTest
    {
        private readonly Mock<ILogger<CarregaEmpresasRepository>> _mockLogger;
        private readonly Mock<List<Empresa>> _mockEmpresas;
        private readonly CarregaEmpresasRepository _carregaEmpresasRepository;

        public CarregaEmpresasRepositoryTest()
        {
            _mockLogger = new Mock<ILogger<CarregaEmpresasRepository>>();
            _mockEmpresas = new Mock<List<Empresa>>();
            _carregaEmpresasRepository = new CarregaEmpresasRepository(_mockLogger.Object); 
        }

        [Fact(DisplayName = "Sucesso ao carregar empresas")]
        public void CarregarEmpresasTest()
        {
            
            var result = _carregaEmpresasRepository.CarregarEmpresas(_mockEmpresas.Object);

            Assert.True(result);
        }
    }
}
