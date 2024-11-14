using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MusicCatalogue_P.Services;
using System.Windows;

namespace MusicCatalogue_P
{
    public partial class App : Application
    {
        public App()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Добавление файла настроек appsettings.json
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    // Считывание ConnectionStrings из конфигурации
                    services.Configure<DbSettings>(context.Configuration.GetSection("ConnectionStrings"));

                    // Настройка DbContext с использованием IOptions
                    services.AddDbContext<MusicDbContext>((serviceProvider, options) =>
                    {
                        var dbSettings = serviceProvider.GetRequiredService<IOptions<DbSettings>>().Value;
                        var dbPath = dbSettings.MusicDb;
                        options.UseSqlite($"Data Source={dbPath}");
                    });
                    // Регистрация MainWindow как Transient
                    services.AddTransient<MainWindow>();

                    // Другие сервисы и зависимости
                });

            var host = builder.Build();

            // Получаем главное окно и показываем его
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            // Запускаем хост для работы с зависимостями
            host.Run();
        }
    }
}
