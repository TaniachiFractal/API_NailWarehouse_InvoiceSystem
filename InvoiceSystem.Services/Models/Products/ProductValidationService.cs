using InvoiceSystem.Models.Products;
using InvoiceSystem.Services.Contracts.Models.Products;

namespace InvoiceSystem.Services.Models.Products
{
    /// <inheritdoc cref="IProductValidationService"/>
    public class ProductValidationService : DBObjectValidationService, IProductValidationService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductValidationService() : base()
        {
            validators.Add(typeof(AddProductModel), new AddProductModelValidator());
            validators.Add(typeof(ProductModel), new ProductModelValidator());
        }
    }
}
