using Aplication.Interfaces;
using Asp.Versioning;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCleanArchServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        AddApiVersioningServices(serviceCollection);
        
        // tem que instalar o Scrutor
        // exemplo 
        // Filtra para pegar apenas classes que estão no namespace de Application ou abaixo
        // .AddClasses(classes => classes.InNamespaceOf<IOrderProcessorService>())
        // Registra apenas classes cujo nome termina em "Service", "Calculator" ou "Checker"
        // .AddClasses(c => c.Where(type => 
        //         type.Name.EndsWith("Service") || 
        //         type.Name.EndsWith("Calculator") ||
        //         type.Name.EndsWith("Checker")))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime()
        serviceCollection.Scan(scan => scan
            // Procura no Assembly (projeto) onde está a interface IOrderProcessorService (Application)
            .FromAssembliesOf(typeof(IOrderProcessorService))
            .AddClasses(c => c.InNamespaces(
                "Application.Services", 
                "Application.Common"
            ))
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            // Procura no Assembly onde está o InventoryChecker e ExternalServices em (Infrastructure)
            .FromAssembliesOf(typeof(InventoryChecker))
            .AddClasses(c => c.InNamespaces(
                "Infrastructure.Persistence", 
                "Infrastructure.ExternalServices"
            ))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        
        return serviceCollection;
    }

    public static void AddApiVersioningServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;

            // Define onde o sistema deve procurar a versão. O 'Combine' permite que a API aceite
            // a versão tanto no segmento da URL quanto na Query String.
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader()
            );
        }).AddApiExplorer(opt =>
        {
            // Define o formato do grupo de versão (Ex: 'v' + Versão -> "v1", "v2").
            opt.GroupNameFormat = "'v'V";

            // Substitui o parâmetro de versão na rota (ex: api/v{version}/...) pelo valor real, 
            // facilitando a geração correta dos caminhos no Swagger.
            opt.SubstituteApiVersionInUrl = true;
        });
    }
}