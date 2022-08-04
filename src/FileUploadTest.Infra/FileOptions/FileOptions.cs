namespace FileUploadTest.Infra.FileOptions;

public sealed class FileOptions
{
    public string FilePath { get; set; }
    public string PermittedExtension { get; set; }
    public string MaxSize { get; set; }
}