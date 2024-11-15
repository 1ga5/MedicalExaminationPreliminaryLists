using System.Linq.Expressions;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Common
{
    /// <summary>
    /// Определяет базовый интерфейс репозитория для выполнения CRUD операций над сущностями типа T.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получает все актуальные (неудаленные) сущности в виде IQueryable.
        /// </summary>
        /// <returns>IQueryable всех актуальных сущностей.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Получает все сущности, включая помеченные на удаление, в виде IQueryable.
        /// </summary>
        /// <returns>IQueryable всех сущностей, включая удаленные.</returns>
        IQueryable<T> GetAllWithDeleted();

        /// <summary>
        /// Асинхронно находит сущность по ее ключу.
        /// </summary>
        /// <param name="id">Значение ключа сущности.</param>
        /// <returns>Задача, представляющая асинхронную операцию, содержащая найденную сущность или null.</returns>
        Task<T?> GetByKeyAsync(int id);

        /// <summary>
        /// Синхронно находит сущность по ее ключу.
        /// </summary>
        /// <param name="id">Значение ключа сущности.</param>
        /// <returns>Найденная сущность или null.</returns>
        T? GetByKey(int id);

        /// <summary>
        /// Находит сущности, удовлетворяющие заданному условию, с возможностью пропуска и ограничения количества.
        /// </summary>
        /// <param name="predicate">Выражение для фильтрации сущностей.</param>
        /// <param name="skip">Количество пропускаемых сущностей.</param>
        /// <param name="take">Количество выбираемых сущностей.</param>
        /// <returns>IQueryable сущностей, удовлетворяющих условию, с примененными параметрами skip и take.</returns>
        IQueryable<T> FindByWithTake(Expression<Func<T, bool>> predicate, int skip, int take);

        /// <summary>
        /// Находит сущности, удовлетворяющие заданному условию.
        /// </summary>
        /// <param name="predicate">Выражение для фильтрации сущностей.</param>
        /// <returns>IQueryable сущностей, удовлетворяющих условию.</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Асинхронно возвращает первую сущность, удовлетворяющую заданному условию.
        /// </summary>
        /// <param name="predicate">Выражение для фильтрации сущностей.</param>
        /// <returns>Задача, представляющая асинхронную операцию, содержащая первую найденную сущность или null.</returns>
        Task<T?> FirstAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Синхронно возвращает первую сущность, удовлетворяющую заданному условию.
        /// </summary>
        /// <param name="predicate">Выражение для фильтрации сущностей.</param>
        /// <returns>Первая найденная сущность или null.</returns>
        T? First(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Добавляет новую сущность в репозиторий.
        /// </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        void Add(T entity);

        /// <summary>
        /// Удаляет сущность из репозитория.
        /// </summary>
        /// <param name="entity">Удаляемая сущность.</param>
        void Delete(T entity);

        /// <summary>
        /// Помечает сущность как удаленную без фактического удаления из базы данных.
        /// </summary>
        /// <param name="entity">Сущность для пометки на удаление.</param>
        /// <param name="userId">Идентификатор пользователя, выполняющего удаление.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        Task VirtualDelete(T entity, int userId);

        /// <summary>
        /// Помечает сущность как удаленную по ее идентификатору без фактического удаления из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор сущности для пометки на удаление.</param>
        /// <param name="userId">Идентификатор пользователя, выполняющего удаление.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        Task VirtualDelete(int id, int userId);

        /// <summary>
        /// Обновляет существующую сущность в репозитории.
        /// </summary>
        /// <param name="entity">Сущность с обновленными данными.</param>
        void Edit(T entity);

        /// <summary>
        /// Синхронно сохраняет все изменения в контексте базы данных.
        /// </summary>
        void Save();

        /// <summary>
        /// Асинхронно сохраняет все изменения в контексте базы данных.
        /// </summary>
        /// <returns>Задача, представляющая асинхронную операцию сохранения.</returns>
        Task SaveChangesAsync();
    }
}
