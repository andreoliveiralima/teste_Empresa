using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Teste_Empresa.Domain;
using Teste_Empresa.Interface;

namespace Teste_Empresa.Repository
{
    public class CarregaEmpresasRepository : ICarregaEmpresas
    {
        private readonly ILogger<CarregaEmpresasRepository> _logger;
        public CarregaEmpresasRepository(ILogger<CarregaEmpresasRepository> logger)
        {
            _logger = logger;
        }
        public bool CarregarEmpresas(List<Empresa> listaEmpresa)
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
