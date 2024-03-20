using DbLogger.Application.AppData.Repository;
using DbLogger.Contracts;
using DbLogger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLogger.Application.AppData.Service
{
    /// <inheritdoc cref="ILogService"/>
    public class LogService : ILogService
    {
        private readonly ILogMessageRepository _logRepository;

        public LogService(ILogMessageRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <inheritdoc cref="ILogService.AddLogMessageAsync(CancellationToken cancellationToken, string message)"/>
        public async Task<Guid> AddLogMessageAsync(CancellationToken cancellationToken, string message)
        {
            var logMessage = new Domain.LogMessage
            {
                ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId,
                Timestamp = DateTime.UtcNow,
                Message = message
            };
            return await _logRepository.AddLogMessageAsync(logMessage, cancellationToken);
        }

        /// <inheritdoc cref="ILogService.DeleteLogMessageAsync(Guid id, CancellationToken cancellationToken)"/>
        public async Task DeleteLogMessageAsync(Guid id, CancellationToken cancellationToken)
        {
            var logMessages = await _logRepository.GetAllLogMessagesAsync(cancellationToken);

            var log = logMessages.Select(s => new ReadLogDto
            {
                Id = s.Id,
                ThreadId = s.ThreadId,
                Timestamp = s.Timestamp,
                Message = s.Message
            }).Where(s => s.Id.Equals(id));

            if (log == null)
            {
                throw new Exception($"Лог с идентификатором {id} не найден.");
            }

            await _logRepository.DeleteLogMessageAsync(id, cancellationToken);
        }


        /// <inheritdoc cref="ILogService.GetAllLogMessagesAsync(CancellationToken cancellationToken)"/>
        public async Task<List<ReadLogDto>> GetAllLogMessagesAsync(CancellationToken cancellationToken)
        {
            var logMessages = await _logRepository.GetAllLogMessagesAsync(cancellationToken);
            var logs = logMessages.Select(s => new ReadLogDto
            {
                Id = s.Id,
                ThreadId = s.ThreadId,
                Timestamp = s.Timestamp,
                Message = s.Message
            });
            return logs.ToList();
        }


        /// <inheritdoc cref="ILogService.GetLogMessageByIdAsync(Guid id, CancellationToken cancellationToken)"/>
        public async Task<ReadLogDto> GetLogMessageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var log = await _logRepository.GetLogMessageByIdAsync(id, cancellationToken);
            if (log == null)
            {
                throw new Exception($"Лог с идентификатором {id} не найдена");
            }
            var result = new ReadLogDto
            {
                Id = log.Id,
                Message = log.Message,
                ThreadId = log.ThreadId,
                Timestamp = log.Timestamp
            };

            
            return result;
        }
    }
}
