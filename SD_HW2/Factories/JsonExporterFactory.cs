namespace SD_HW2.Export;

public sealed class JsonExporterFactory : IExporterFactory
{
    public IAccountVisitor CreateExporter() => new JsonExportVisitor();

    public string FileExtension { get; } = "json";
}