using Moq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;
using Teste_Empresa.Controllers;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Teste_Empresa.Domain;
using Teste_Empresa.Interface;

namespace Empresa_Test.Controllers
{
    public class EmpresaControllerTest
    {
        private readonly Mock<ILogger<EmpresaController>> _mockLogger;
        
        private readonly Mock<ICarregaEmpresas> _mockCarregaEmpresa;

        public EmpresaControllerTest()
        {
            _mockLogger = new Mock<ILogger<EmpresaController>>();
            _mockCarregaEmpresa = new Mock<ICarregaEmpresas>();
        }

        [Theory(DisplayName ="Sucesso ao buscar empresa")]
        [InlineData(1)]
        [InlineData(2)]
        public async Task BuscarEmpresa(int id)
        {
            var command = new EmpresaController(_mockLogger.Object, _mockCarregaEmpresa.Object);
            var response = await command.Get(id);

            Assert.Equal(HttpStatusCode.OK.GetHashCode(), ((ObjectResult)response).StatusCode);
        }

        

    }
}