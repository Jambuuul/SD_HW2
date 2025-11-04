using System.Text;
using SD_HW2.Export;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
using SD_HW2.Strategy;

namespace SD_HW2.ConsoleInteraction;

public sealed class ExportAccountsPage : Page
{
    private static List<IExportFilter> filters =
    [
        new DefaultExportFilter(),
        new MillionaireExportFilter()
    ];
    
    protected override void Render()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Выберите тип экспорта")
                .AddChoices(["CSV", "JSON"])
        );
        
        var filter = AnsiConsole.Prompt(
            new SelectionPrompt<IExportFilter>()
                .Title("Выберите фильтр")
                .AddChoices(filters)
                .UseConverter(fltr => fltr.ToString())
            );

        var exportService = CompositionRoot.Services.GetRequiredService<SecuredAccountExporterProxy>();
        IExporterFactory factory = choice switch
        {
            "CSV" =>  new CsvExporterFactory(),
            "JSON" => new JsonExporterFactory()
        };

        factory.Filter = filter;

        exportService.ExportToFile(factory);
    }
}