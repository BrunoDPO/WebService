using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebService;

var builder = WebApplication.CreateBuilder(args);
// Adicionar suporte ao WSDL
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
// Adiciona o serviço no container de injeção de dependência
builder.Services.AddSingleton<OlaMundoService>();

var app = builder.Build();

// Cria um binding sem credencial para HTTPS
var basicHttpsBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
basicHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

app.UseServiceModel(builder =>
{
    builder.AddService<OlaMundoService>(serviceOptions => { })
        .AddServiceEndpoint<OlaMundoService, IOlaMundoService>(new BasicHttpBinding(), "/OlaMundo.svc")
        .AddServiceEndpoint<OlaMundoService, IOlaMundoService>(basicHttpsBinding, "/OlaMundo.svc")
        ;
});

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;
serviceMetadataBehavior.HttpsGetEnabled = true;

app.Run();
