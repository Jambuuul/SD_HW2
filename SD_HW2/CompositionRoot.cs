using SD_HW2.Export;

namespace SD_HW2;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Синглтон класс DI контейнера с семинара
/// </summary>
public static class CompositionRoot
{
    private static IServiceProvider? _services; // наш сервис локатор
    public static IServiceProvider Services => _services ??= CreateServiceProvider();

    /// <summary>
    /// Создание сервис локатора
    /// </summary>
    /// <returns>локатор</returns>
    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        
        // добавление зависимостей
        services.AddSingleton<AccountExportService>();
        
        return services.BuildServiceProvider(); // строим контейнер зависимостей
    }
}