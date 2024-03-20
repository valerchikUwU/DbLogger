using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DbLogger.Application.AppData.Repository
{
    /// <summary>
    /// Репозиторий для работы с логами.
    /// </summary>
    public interface ILogMessageRepository
    {
        /// <summary>
        /// Добавить лог
        /// </summary>
        /// <param name="logMessage">Сообщение лога</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор</returns>
        Task<Guid> AddLogMessageAsync(Domain.LogMessage logMessage, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить лог
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор удаленного лога</returns>
        Task DeleteLogMessageAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все логи
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список логов</returns>
        Task<List<Domain.LogMessage>> GetAllLogMessagesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить лог по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Лог</returns>
        Task<Domain.LogMessage> GetLogMessageByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
