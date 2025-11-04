using SD_HW2.Strategy;

namespace SD_HW2.Export;

public interface IExporterFactory
{
    IAccountVisitor CreateExporter();
    IExportFilter Filter { get; set; }
    string FileExtension { get; }
}