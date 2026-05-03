using Asp.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCleanArchServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        AddApiVersioningServices(serviceCollection);
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