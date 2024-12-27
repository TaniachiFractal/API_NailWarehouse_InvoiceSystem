using AutoMapper;
using InvoiceSystem.Api.Models;
using InvoiceSystem.Api.Models.Customers;
using InvoiceSystem.Api.Models.Invoices;
using InvoiceSystem.Api.Models.Products;
using InvoiceSystem.Api.Models.Sales;
using InvoiceSystem.Models;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Api.Infrastructure
{
    /// <summary>
    /// Профиль API для связки типов
    /// </summary>
    public class ApiMapperProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ApiMapperProfile()
        {
            CreateMap<CustomerModel, CustomerApiModel>(MemberList.Destination);
            CreateMap<AddCustomerApiModel, AddCustomerModel>(MemberList.Destination);
            CreateMap<AddCustomerApiModel, CustomerModel>(MemberList.Destination);

            CreateMap<InvoiceModel, InvoiceApiModel>(MemberList.Destination);
            CreateMap<AddInvoiceApiModel, AddInvoiceModel>(MemberList.Destination);
            CreateMap<AddInvoiceApiModel, InvoiceModel>(MemberList.Destination);

            CreateMap<ProductModel, ProductApiModel>(MemberList.Destination);
            CreateMap<AddProductApiModel, AddProductModel>(MemberList.Destination);
            CreateMap<AddProductApiModel, ProductModel>(MemberList.Destination);

            CreateMap<SaleModel, SaleApiModel>(MemberList.Destination);
            CreateMap<AddSaleApiModel, AddSaleModel>(MemberList.Destination);
            CreateMap<AddSaleApiModel, SaleModel>(MemberList.Destination);

            CreateMap<ProductInvoiceListingModel, ProductInvoiceListingApiModel>();
            CreateMap<FullInvoiceInfoModel, FullInvoiceInfoApiModel>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}
