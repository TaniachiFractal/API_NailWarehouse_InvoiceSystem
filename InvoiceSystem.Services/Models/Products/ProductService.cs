using AutoMapper;
using InvoiceSystem.Database;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Services.Contracts.Models.Products;

namespace InvoiceSystem.Services.Models.Products
{
    /// <inheritdoc cref="IProductService"/>
    public class ProductService
        : DBObjectService<AddProductModel, ProductModel, Product>,
        IProductService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductService(InvcSysDBContext dbContext, IMapper mapper) : base(dbContext, dbContext.Products, mapper)
        {
        }
    }
}
