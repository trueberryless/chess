using Microsoft.AspNetCore.Builder;

namespace Chess.Infrastructure;

public static class InfrastructureFactory
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        return builder;
    }
}