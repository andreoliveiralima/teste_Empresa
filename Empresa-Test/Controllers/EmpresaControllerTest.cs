using Moq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;
using Teste_Empresa.Controllers;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Teste_Empresa.Domain;

namespace Empresa_Test.Controllers
{
    public class EmpresaControllerTest
    {
        private readonly Mock<ILogger<EmpresaController>> _mockLogger;
        private readonly Mock<List<Empresa>> _mockEmpresas;

        public EmpresaControllerTest()
        {
            _mockLogger = new Mock<ILogger<EmpresaController>>();
            _mockEmpresas = new Mock<List<Empresa>>();
        }

        [Theory(DisplayName ="Sucesso ao buscar empresa")]
        [InlineData(1)]
        [InlineData(2)]
        public async Task BuscarEmpresa(int id)
        {
            var command = new EmpresaController(_mockLogger.Object);
            var response = await command.Get(id);

            Assert.Equal(HttpStatusCode.OK.GetHashCode(), ((ObjectResult)response).StatusCode);
        }

        [Fact(DisplayName = "Sucesso ao carregar empresas")]
        public void CarregarEmpresa()
        {
            var command = new EmpresaController(_mockLogger.Object);
            var result = command.CarregaEmpresas(_mockEmpresas.Object);

            Assert.True(result);
        }

    }
}