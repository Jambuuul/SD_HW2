namespace SD_HW2.Export;

public sealed class CsvExporterFactory : IExporterFactory
{
    public IAccountVisitor CreateExporter() => new CsvExportVisitor();
    public string FileExtension { get; } = "csv";
}