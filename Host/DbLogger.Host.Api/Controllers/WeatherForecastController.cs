using Microsoft.AspNetCore.Mvc;
using DbLogger.Application.AppData.Service;
using System.Threading;
using DbLogger.Contracts;
using System.Net;

namespace DbLogger.Host.Api.Controllers
{

    /// <summary>
    /// Иммитационный контроллер для примера работы логгирования
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogService _logService;


        /// <summary>
        /// Инициализиурет экземпляр контроллера
        /// </summary>
        /// <param name="logService">Сервис логгирования</param>
        public WeatherForecastController(ILogService logService)
        {
            _logService = logService;
        }


        /// <summary>
        /// Пример post запроса
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Ошибка 500, добавление лога об ошибке</returns>
        [HttpPost("anyAction")]
        public async Task<ActionResult<Guid>> AnyPostActionAsync(CancellationToken cancellationToken)
        {
            try
            {
                throw new Exception("Искусственное исключение");
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                await _logService.AddLogMessageAsync(cancellationToken, $"Ошибка: {ex.Message}");
                return StatusCode(500, "Произошла ошибка.");
            }
        }


        /// <summary>
        /// Пример get запроса
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Код 200, добавление лога об успешном выполнении</returns>
        [HttpGet("anyAction")]
        public async Task<ActionResult<Guid>> AnyGetActionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _logService.AddLogMessageAsync(cancellationToken, "Выполнено AnyGetActionAsync");
                
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                await _logService.AddLogMessageAsync(cancellationToken, $"Ошибка: {ex.Message}");
                return StatusCode(500, "Произошла ошибка.");
            }
        }

    }
}