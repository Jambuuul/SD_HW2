namespace SD_HW2.Export;
using SD_HW2.Strategy;

public sealed class JsonExporterFactory : IExporterFactory
{
    public IExportFilter Filter { get; set; } = new DefaultExportFilter();
    public IAccountVisitor CreateExporter()
    {
        var visitor = new JsonExportVisitor();
        visitor.Filter = Filter;
        return visitor;
    }
    public string FileExtension { get; } = "json";
}