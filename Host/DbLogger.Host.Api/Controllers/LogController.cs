using DbLogger.Application.AppData.Service;
using DbLogger.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DbLogger.Host.Api.Controllers
{

    /// <summary>
    /// Контроллер для работы с логами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;


        /// <summary>
        ///  Инициализиурет экземпляр контроллера
        /// </summary>
        /// <param name="logService">Сервис логгирования</param>
        public LogController(ILogService logService)
        {
            _logService = logService;
        }


        /// <summary>
        /// Получить все логи
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список логов</returns>
        [HttpGet("logs")]
        public async Task<ActionResult<List<ReadLogDto>>> GetLogs(CancellationToken cancellationToken)
        {
            
                var logs = await _logService.GetAllLogMessagesAsync(cancellationToken);
                return StatusCode((int)HttpStatusCode.OK, logs);

        }


        /// <summary>
        /// Удаляет лог
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор удаленного лога</returns>
        [HttpDelete("log/{id}")]
        public async Task<IActionResult> DeleteLog(Guid id, CancellationToken cancellationToken)
        {
            await _logService.DeleteLogMessageAsync(id, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, id);
        }


        /// <summary>
        /// Получить лог по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Лог</returns>
        [HttpGet("log/{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _logService.GetLogMessageByIdAsync(id, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return StatusCode((int)HttpStatusCode.OK, result);
        }
    }
}
