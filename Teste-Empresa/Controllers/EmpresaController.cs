using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
            List<Empresa> listaEmpresa = new List<Empresa>();
            CarregaEmpresas(listaEmpresa);

            EmpresaResponse empresaResponse = new EmpresaResponse();

            empresaResponse.NomeEmpresa = listaEmpresa.FirstOrDefault(x => x.Id == id).NomeEmpresa;

            return Ok(empresaResponse);
        }

        private void CarregaEmpresas(List<Empresa> listaEmpresa)
        {
            listaEmpresa.Add(new Empresa() { Id = 1, NomeEmpresa = "Itaú" });
            listaEmpresa.Add(new Empresa() { Id = 2, NomeEmpresa = "Petrobras" });
        }
    }
}
