using System.Diagnostics.CodeAnalysis;
using Scalar.AspNetCore;
// ReSharper disable RedundantArgumentDefaultValue

namespace Guths.Cep.Api.Configuration.IoC;

[ExcludeFromCodeCoverage]
public static class ScalarConfig
{
    // https://github.com/scalar/scalar/blob/main/documentation/integrations/dotnet.md
    public static void AddScalarConfiguration(this WebApplication app, string projectName)
    {
        app.MapOpenApi();

        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle(projectName)
                .WithSidebar(true)
                .WithTheme(ScalarTheme.Moon)
                .WithDarkMode(true)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
                .WithDarkModeToggle(false);
        });

        app.Use(async (context, next) =>
        {
            if (context.Request.Path == "/")
            {
                context.Response.Redirect("/scalar/v1", permanent: false);
                return;
            }
            await next();
        });
    }
}
