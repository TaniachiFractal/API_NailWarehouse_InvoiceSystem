using System.Reflection;
using InvoiceSystem.Api.Infrastructure;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;
using InvoiceSystem.Repositories.Contracts.Sales;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.Repositories.Sales;
using InvoiceSystem.Services;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Contracts.Models.Customers;
using InvoiceSystem.Services.Contracts.Models.Invoices;
using InvoiceSystem.Services.Contracts.Models.Products;
using InvoiceSystem.Services.Contracts.Models.Sales;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.Services.Models.Invoices;
using InvoiceSystem.Services.Models.Products;
using InvoiceSystem.Services.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Api
{
    static internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(c =>
            {
                c.Filters.Add<ExceptionFilter>();
            });

            #region DB

            builder.Services.AddDbContext<InvcSysDBContext>(c =>
            {
                c.UseSqlServer(builder.Configuration.GetConnectionString("MainCon"));
            });

            builder.Services.AddScoped<IReader>(c => c.GetRequiredService<InvcSysDBContext>());
            builder.Services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<InvcSysDBContext>());
            builder.Services.AddScoped<IWriter>(c => c.GetRequiredService<InvcSysDBContext>());

            #endregion

            #region Repositories

            builder.Services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            builder.Services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

            builder.Services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
            builder.Services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();

            builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();

            builder.Services.AddScoped<ISaleWriteRepository, SaleWriteRepository>();
            builder.Services.AddScoped<ISaleReadRepository, SaleReadRepository>();

            #endregion

            #region Services

            builder.Services.AddScoped<IMainService, MainService>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ISaleService, SaleService>();

            #endregion

            #region Validation Services

            builder.Services.AddScoped<ICustomerValidationService, CustomerValidationService>();
            builder.Services.AddScoped<IInvoiceValidationService, InvoiceValidationService>();
            builder.Services.AddScoped<IProductValidationService, ProductValidationService>();
            builder.Services.AddScoped<ISaleValidationService, SaleValidationService>();

            #endregion

            builder.Services.AddSingleton<IDateTimeOffsetProvider, DateTimeOffsetProvider>();
            builder.Services.AddAutoMapper(typeof(ApiMapperProfile), typeof(AppAutoMapperProfile));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            var app = builder.Build();

            #region app

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<AuthorMiddleware>();
            app.MapControllers();
            app.Run();

            #endregion
        }
    }
}
