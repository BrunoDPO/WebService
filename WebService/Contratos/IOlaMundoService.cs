using CoreWCF;
using System.Threading.Tasks;

namespace WebService.Contratos;

[ServiceContract]
public interface IOlaMundoService
{
    [OperationContract]
    Task<string> OlaMundoAsync(string text);
}
