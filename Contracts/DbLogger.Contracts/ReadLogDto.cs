using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLogger.Contracts
{
    /// <summary>
    /// Модель лога
    /// </summary>
    public class ReadLogDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор потока
        /// </summary>
        public int ThreadId { get; set; }

        /// <summary>
        /// Доп. сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Время лога
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
    }
}
