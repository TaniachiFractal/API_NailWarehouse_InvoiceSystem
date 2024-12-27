using AutoMapper;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Products;
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
        public ProductService(IMapper mapper, IProductReadRepository readRepository, IProductWriteRepository writeRepository, IUnitOfWork unitOfWork)
            : base(mapper, readRepository, writeRepository, unitOfWork)
        {
        }
    }
}
