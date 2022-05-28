using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Teste_Empresa.Domain;

namespace Teste_Empresa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(EmpresaResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Solicitado Nome Empresa id:{id}");
                List<Empresa> listaEmpresa = new List<Empresa>();
                CarregaEmpresas(listaEmpresa);

                EmpresaResponse empresaResponse = new EmpresaResponse();

                empresaResponse.NomeEmpresa = listaEmpresa.FirstOrDefault(x => x.Id == id)?.NomeEmpresa;
                if(empresaResponse.NomeEmpresa != null)
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
                _logger.LogError($"Erro ao localizar empresa - {ex.Message}" );
                return BadRequest("Erro Interno - Contate o responsável");
            }
            
        }

        public bool CarregaEmpresas(List<Empresa> listaEmpresa)
        {
            try
            {
                _logger.LogInformation("Carregando as empresas...");
                listaEmpresa.Add(new Empresa() { Id = 1, NomeEmpresa = "Itaú" });
                listaEmpresa.Add(new Empresa() { Id = 2, NomeEmpresa = "Petrobras" });
                _logger.LogInformation("...Empresas Carregadas");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao carregar as empresas - {ex.Message}");
                return false;
            }
            
        }
    }
}
