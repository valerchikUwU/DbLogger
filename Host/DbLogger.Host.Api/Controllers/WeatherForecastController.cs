using Microsoft.AspNetCore.Mvc;
using DbLogger.Application.AppData.Service;
using System.Threading;
using DbLogger.Contracts;
using System.Net;

namespace DbLogger.Host.Api.Controllers
{

    /// <summary>
    /// ������������� ���������� ��� ������� ������ ������������
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogService _logService;


        /// <summary>
        /// �������������� ��������� �����������
        /// </summary>
        /// <param name="logService">������ ������������</param>
        public WeatherForecastController(ILogService logService)
        {
            _logService = logService;
        }


        /// <summary>
        /// ������ post �������
        /// </summary>
        /// <param name="cancellationToken">����� ������</param>
        /// <returns>������ 500, ���������� ���� �� ������</returns>
        [HttpPost("anyAction")]
        public async Task<ActionResult<Guid>> AnyPostActionAsync(CancellationToken cancellationToken)
        {
            try
            {
                throw new Exception("������������� ����������");
            }
            catch (Exception ex)
            {
                // ����������� ������
                await _logService.AddLogMessageAsync(cancellationToken, $"������: {ex.Message}");
                return StatusCode(500, "��������� ������.");
            }
        }


        /// <summary>
        /// ������ get �������
        /// </summary>
        /// <param name="cancellationToken">����� ������</param>
        /// <returns>��� 200, ���������� ���� �� �������� ����������</returns>
        [HttpGet("anyAction")]
        public async Task<ActionResult<Guid>> AnyGetActionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _logService.AddLogMessageAsync(cancellationToken, "��������� AnyGetActionAsync");
                
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                // ����������� ������
                await _logService.AddLogMessageAsync(cancellationToken, $"������: {ex.Message}");
                return StatusCode(500, "��������� ������.");
            }
        }

    }
}