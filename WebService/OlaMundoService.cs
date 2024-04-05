using CoreWCF;
using Microsoft.Extensions.Logging;

namespace WebService;

[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
public class OlaMundoService : IOlaMundoService
{
    private readonly ILogger<OlaMundoService> _logger;

    public OlaMundoService(ILogger<OlaMundoService> logger)
    {
        _logger = logger;
    }

    public string OlaMundo(string text)
    {
        _logger.LogInformation("Chamada ao endpoint {Endpoint}", nameof(OlaMundo));
        return $"Olá {text}";
    }
}
