# Простой ручной сервис логирования в бд MSSql для ASP.NET

Этот репозиторий содержит код для простого ручного сервиса логирования в базу данных MSSql для приложений на ASP.NET. Сервис позволяет добавлять, удалять и просматривать список всех логов.

## Содержание

- [Установка](#установка)
- [Использование](#использование)
- [Дополнительная информация](#дополнительная-информация)
- [Пример работы](#пример-работы)

## Установка

1. **Клонирование репозитория**

   Сначала клонируйте репозиторий на ваш локальный компьютер:

   ```
   git clone https://github.com/yourusername/log-service.git
   ```

2. **Настройка базы данных**

   Создайте базу данных MSSql 

3. **Настройка строки подключения**

   В файле `appsettings.json` укажите строку подключения к вашей базе данных MSSql:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=your_database;"
     }
   }
   ```

4. **Запуск приложения**

   Запустите приложение из Visual Studio или используя .NET CLI:

   ```
   dotnet run
   ```

## Использование

После запуска приложения вы можете использовать следующие функции:

- **Добавление лога**: Отправьте POST-запрос на `/api/logs` с телом запроса, содержащим информацию о логе.

- **Удаление лога**: Отправьте DELETE-запрос на `/api/logs/{id}`, где `{id}` - это идентификатор лога, который вы хотите удалить.

- **Просмотр списка логов**: Отправьте GET-запрос на `/api/logs` для получения списка всех логов.
  
- **Выборка по идентификатору**: Отправьте GET-запрос на `/api/logs{id}` для получения лога по id.

## Дополнительная информация

- **Технологии**: ASP.NET Core, Entity Framework Core, MSSql
- **Структура проекта**:
 - `src/Host/DbLogger.Host.Api/Controllers/LogController.cs` - контроллер для обработки запросов к логам.
 - `src/Host/DbLogger.Host.Api/Controllers/WeatherForecastController.cs` - контроллер для демонстрации работы логгирования.
 - `src/Host/DbLogger.Host.DbMigrator` - мигратор БД
 - `src/Domain/DbLogger.Domain/LogMessage.cs` - модель данных для лога.
 - `src/Contracts/DbLogger.Contracts/ReadLogDto.cs` - дто лога.
 - `src/Application/DbLogger.Application.AppData/Repository/ILogMessageRepository.cs` - Репозиторий для работы с логами.
 - `src/Application/DbLogger.Application.AppData/Service` - Сервис для работы с логами.
 - `src/Infrastructure/DbLogger.Infrastructure/Repository` - базовый репозиторий
 - `src/Infrastructure/DbLogger.Infrastructure.DataAccess` - подключение к БД и конфигурация модели

##Пример работы
Создали искусственное исключение
![image](https://github.com/valerchikUwU/DbLogger/assets/99470988/673917d8-7daf-43ca-aa7f-fe27ad6b5bd0)

В списке логов нашли лог об искусственном исключении

![image](https://github.com/valerchikUwU/DbLogger/assets/99470988/90472c31-3015-42c1-8428-853096305435)

