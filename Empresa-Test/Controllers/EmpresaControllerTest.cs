using Moq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;
using Teste_Empresa.Controllers;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Empresa_Test.Controllers
{
    public class EmpresaControllerTest
    {
        private readonly Mock<ILogger<EmpresaController>> _mockLogger;

        public EmpresaControllerTest()
        {
            _mockLogger = new Mock<ILogger<EmpresaController>>();
        }

        [Theory(DisplayName ="Sucesso")]
        [InlineData(1)]
        [InlineData(2)]
        public async Task BuscarEmpresa(int id)
        {
            var command = new EmpresaController(_mockLogger.Object);
            var response = await command.Get(id);

            Assert.Equal(HttpStatusCode.OK.GetHashCode(), ((ObjectResult)response).StatusCode);
        }

    }
}