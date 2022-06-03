using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Teste_Empresa.Domain;
using Teste_Empresa.Interface;

namespace Teste_Empresa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly ILogger<EmpresaController> _logger;
        private readonly ICarregaEmpresas _carregaEmpresa;

        public EmpresaController(ILogger<EmpresaController> logger, ICarregaEmpresas carregaEmpresas)
        {
            _logger = logger;
            _carregaEmpresa = carregaEmpresas;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(EmpresaResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] EmpresaRequest request)
        {
            try
            {
                _logger.LogInformation($"Solicitado Nome Empresa id:{request.Id}");
                List<Empresa> listaEmpresa = new List<Empresa>();
                _carregaEmpresa.CarregarEmpresas(listaEmpresa);

                EmpresaResponse empresaResponse = new EmpresaResponse();

                empresaResponse.NomeEmpresa = listaEmpresa.FirstOrDefault(x => x.Id == request.Id)?.NomeEmpresa;
                if (empresaResponse.NomeEmpresa != null)
                {
                    _logger.LogInformation($"Empresa Localizada: {empresaResponse.NomeEmpresa}");
                }
                else
                {
                    _logger.LogInformation($"Empresa Não Localizada");
                }

                return Ok(empresaResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                return BadRequest("Erro Interno");
            }

        }

    }
}
