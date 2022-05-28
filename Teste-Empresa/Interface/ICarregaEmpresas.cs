using System.Collections.Generic;
using Teste_Empresa.Domain;

namespace Teste_Empresa.Interface
{
    public interface ICarregaEmpresas
    {
        bool CarregarEmpresas(List<Empresa> listaEmpresa);
    }
}
