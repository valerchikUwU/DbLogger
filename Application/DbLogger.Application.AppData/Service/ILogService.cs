using DbLogger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLogger.Application.AppData.Service
{
    /// <summary>
    /// Сервис для работы с логами
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Добавление лога
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <param name="message">Доп. сообщение</param>
        /// <returns>Идентификатор лога</returns>
        Task<Guid> AddLogMessageAsync(CancellationToken cancellationToken, string message);

        /// <summary>
        /// Удалить лог
        /// </summary>
        /// <param name="id">Идентификатор лога</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        Task DeleteLogMessageAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все логи
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список логов</returns>
        Task<List<ReadLogDto>> GetAllLogMessagesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить лог по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Модель лога</returns>
        Task<ReadLogDto> GetLogMessageByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
