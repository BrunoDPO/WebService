using CoreWCF;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebService.Contratos;

namespace WebService.Servicos;

[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession, AddressFilterMode = AddressFilterMode.Any)]
public class OlaMundoService : IOlaMundoService
{
    private readonly ILogger<OlaMundoService> _logger;

    public OlaMundoService(ILogger<OlaMundoService> logger)
    {
        _logger = logger;
    }

    public Task<string> OlaMundoAsync(string text)
    {
        _logger.LogInformation("Chamada ao endpoint {Endpoint}", nameof(OlaMundoAsync));
        return Task.FromResult($"Olá {text}");
    }
}
