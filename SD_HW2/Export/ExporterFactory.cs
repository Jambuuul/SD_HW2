namespace SD_HW2.Export;


public enum ExportFormat
{
    Csv,
    Json
}

public static class ExporterFactory
{
    public static IAccountVisitor Create(ExportFormat format) => format switch
    {
        ExportFormat.Csv => new CsvExportVisitor(),
        ExportFormat.Json => new JsonExportVisitor(),
    };
}