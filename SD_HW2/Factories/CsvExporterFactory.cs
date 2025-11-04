using SD_HW2.Strategy;

namespace SD_HW2.Export;

public sealed class CsvExporterFactory : IExporterFactory
{
    public IAccountVisitor CreateExporter()
    {
        var visitor = new CsvExportVisitor();
        visitor.Filter = Filter;
        return visitor;
    }
    public IExportFilter Filter { get; set; } = new DefaultExportFilter();
    public string FileExtension { get; } = "csv";
}