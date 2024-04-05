using CoreWCF;

namespace WebService;

[ServiceContract]
public interface IOlaMundoService
{
    [OperationContract]
    string OlaMundo(string text);
}
