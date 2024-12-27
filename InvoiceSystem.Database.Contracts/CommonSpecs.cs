using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Database.Contracts
{
    /// <summary>
    /// Общие настройки поиска
    /// </summary>
    public static class CommonSpecs
    {
        /// <summary>
        /// Не имеет даты удаления
        /// </summary>
        public static IQueryable<T> NotDeleted<T>(this IQueryable<T> set)
            where T : ISoftDeleted
            => set.Where(x => x.DeletedDate == null);

        /// <summary>
        /// Имеет ID
        /// </summary>
        public static IQueryable<T> WithId<T>(this IQueryable<T> set, Guid id)
            where T : IUniqueID
            => set.Where(x => x.Id == id);
    }
}
