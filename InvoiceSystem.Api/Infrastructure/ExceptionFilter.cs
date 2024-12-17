using InvoiceSystem.Api.ErrorModels;
using InvoiceSystem.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InvoiceSystem.Api.Infrastructure
{
    /// <summary>
    /// Фильтр исключений
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception is InvcSysException exception)
            {
                switch (exception)
                {
                    case NotFoundException:
                        SetHandledException(context, new NotFoundObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status404NotFound
                        }));
                        break;
                    case ValidationErrorException supEx:
                        SetHandledException(context, new ObjectResult(new ValidationErrorModel
                        {
                            Errors = supEx.Errors.Select(x =>
                            new OneValidationError(x.Field, x.Message))
                        })
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable
                        });
                        break;
                    case OperationException:
                        SetHandledException(context, new ConflictObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status409Conflict
                        }));
                        break;
                    default:
                        SetHandledException(context, new BadRequestObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status400BadRequest
                        }));
                        break;
                }
            }
        }

        private static void SetHandledException(ExceptionContext context, ObjectResult result)
        {
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
