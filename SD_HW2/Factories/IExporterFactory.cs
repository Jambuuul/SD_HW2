namespace SD_HW2.Export;

public interface IExporterFactory
{
    IAccountVisitor CreateExporter();
    string FileExtension { get; }
}