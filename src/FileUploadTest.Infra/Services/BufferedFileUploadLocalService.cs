using Microsoft.AspNetCore.Http;

namespace FileUploadTest.Infra.Services;

public class BufferedFileUploadLocalService : IBufferedFileUploadService
{
    public async Task<Guid?> UploadFile(IFormFile file, string folderName)
    {
        string path = "";

        if (file.Length > 0)
        {
            path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var id = Guid.NewId();
            var newFileName = $"{id}___{file.FileName}";

            if (File.Exists(Path.Combine(path,newFileName )))
            {
                throw new Exception("File Copy Failed");
            }

            using (var fileStream = new FileStream(Path.Combine(path, ), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return id;
        }
        else
        {
            return null;
        }
    }

    public async Task<MemoryStream> Download(Guid fileGuid, string fileName, string folderName)
    {
        var memoryStream = new MemoryStream();

        if (!Path.Combine(filePath, fileName))
        {
            throw new FileNotFoundException();
        }
        
        using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Open))
        {
            await fileStream.CopyToAsync(memoryStream);
        }
        
        memoryStream.Position = 0;

        return memoryStream;
    }
}