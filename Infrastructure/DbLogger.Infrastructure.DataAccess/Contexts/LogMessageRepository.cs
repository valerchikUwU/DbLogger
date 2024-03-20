using DbLogger.Application.AppData.Repository;
using DbLogger.Domain;
using DbLogger.Infrastructure.Repository;
using DbLogger.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DbLogger.Infrastructure.DataAccess.Contexts
{
    public class LogMessageRepository : ILogMessageRepository
    {
        private readonly IRepository<Domain.LogMessage> _repository;

        public LogMessageRepository(IRepository<Domain.LogMessage> repository)
        {
            _repository = repository;
        }
        public async Task<Guid> AddLogMessageAsync(LogMessage logMessage, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(logMessage, cancellationToken);
            return logMessage.Id;
        }

        public async Task DeleteLogMessageAsync(Guid id, CancellationToken cancellationToken)
        {
            var existingLogMessage = await _repository.GetByIdAsync(id, cancellationToken);
            if (existingLogMessage == null)
            {
                return;
            }

            await _repository.DeleteAsync(existingLogMessage, cancellationToken);
        }

        public async Task<List<LogMessage>> GetAllLogMessagesAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAll().ToListAsync(cancellationToken);
        }

        public async Task<Domain.LogMessage> GetLogMessageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }
    }
}
