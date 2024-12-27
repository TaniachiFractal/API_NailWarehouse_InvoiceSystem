using InvoiceSystem.Common;
using InvoiceSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace InvoiceSystem.TestsBase
{
    /// <summary>
    /// База для тестов, использующих базу данных
    /// </summary>
    public class DBTestsBase : IDisposable
    {
        private readonly InvcSysDBContext context;
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly Mock<IDateTimeOffsetProvider> dateTimeMock;
        private readonly Mock<ILogger> loggerMock;

        /// <summary>
        /// Контекст БД
        /// </summary>
        public InvcSysDBContext DbContext => context;

        /// <summary>
        /// Токен отмены
        /// </summary>
        public CancellationToken CancellationToken => cancellationTokenSource.Token;

        /// <summary>
        /// Заглушка модуля даты
        /// </summary>
        public IDateTimeOffsetProvider DateTimeMock => dateTimeMock.Object;

        /// <summary>
        /// Заглушка логгера
        /// </summary>
        public ILogger Logger => loggerMock.Object;

        /// <summary>
        /// Конструктор
        /// </summary>
        protected DBTestsBase()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var opt = new DbContextOptionsBuilder<InvcSysDBContext>()
                .UseInMemoryDatabase($"AppCon{Guid.NewGuid()}")
                .Options;

            loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ));

            context = new InvcSysDBContext(opt);
            dateTimeMock = new Mock<IDateTimeOffsetProvider>();
            dateTimeMock.Setup(t => t.UtcNow).Returns(DateTimeOffset.UtcNow);
            dateTimeMock.Setup(t => t.Now).Returns(DateTimeOffset.Now);
        }

        void IDisposable.Dispose()
        {
            context.Dispose();
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
