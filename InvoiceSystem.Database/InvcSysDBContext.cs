using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Database
{
    /// <summary>
    /// Контекст базы данных системы накладных
    /// </summary>
    /// <remarks>
    /// https://learn.microsoft.com/ru-ru/ef/core/cli/dotnet
    /// dotnet tool install --global dotnet-ef --version 6.0.0
    /// dotnet tool update --global dotnet-ef --version 6.0.0
    /// dotnet ef migrations add InitialCreate --project  WebApi.Context/WebApi.Context.csproj
    /// dotnet ef database update --project WebApi.Context/WebApi.Context.csproj
    /// </remarks>
    public class InvcSysDBContext : DbContext
    {

    }
}
