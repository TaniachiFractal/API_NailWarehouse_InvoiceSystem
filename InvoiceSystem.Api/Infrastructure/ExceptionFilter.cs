using InvoiceSystem.Api.ErrorModels;
using InvoiceSystem.Common;
using InvoiceSystem.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InvoiceSystem.Api.Infrastructure
{
    /// <summary>
    /// Фильтр исключений
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this.logger = logger;
        }

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

                        LogHandledError(exception, context.Exception.Source);
                        break;

                    case ValidationErrorException validEx:
                        SetHandledException(context, new ObjectResult(new ValidationErrorModel
                        {
                            Errors = validEx.Errors.Select(x =>
                            new OneValidationError(x.Field, x.Message))
                        })
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable
                        });

                        LogHandledError(exception, context.Exception.Source);
                        break;

                    case OperationException:
                        SetHandledException(context, new ConflictObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status409Conflict
                        }));

                        LogHandledError(exception, context.Exception.Source);
                        break;

                    default:
                        SetHandledException(context, new BadRequestObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status400BadRequest
                        }));

                        LogHandledError(exception, context.Exception.Source);
                        break;
                }
            }
        }

        private static void SetHandledException(ExceptionContext context, ObjectResult result)
        {
            context.Result = result;
            context.ExceptionHandled = true;
        }

        private void LogHandledError(Exception exception, string source)
        {
            Com.LogHandledError(logger, source, exception);
        }
    }
}
