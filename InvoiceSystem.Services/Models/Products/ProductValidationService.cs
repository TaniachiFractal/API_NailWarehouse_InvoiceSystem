using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Products;
using InvoiceSystem.Services.Contracts.Models.Products;

namespace InvoiceSystem.Services.Models.Products
{
    /// <inheritdoc cref="IProductValidationService"/>
    public class ProductValidationService : DBObjectValidationService, IProductValidationService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductValidationService(IProductReadRepository readRepository) : base()
        {
            validators.Add(typeof(AddProductModel), new AddProductModelValidator(readRepository));
            validators.Add(typeof(ProductModel), new ProductModelValidator(readRepository));
        }
    }
}
