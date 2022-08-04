

namespace FileUploadTest.Infra.Services;

public class BufferedFileUploadLocalService : IBufferedFileUploadService
{
    public async Task<Guid?> UploadFile(IFormFile file, string folderName)
    {
        string path = "";

        if (file.Length > 0)
        {
              // Create continer if not avaialable

            var id = Guid.NewId();
            var newFileName = $"{id}___{file.FileName}";

            string connectionString = "DefaultEndpointsProtocol=https;AccountName=kmccfileupload;AccountKey=h+PFVsQg8A6A9S43/lDDABLNO6GyzGTmGRgH6op5KHwXo85jyBrD7XivcCtWvZvZJHNFIp84my43+AStWH/JCw==;EndpointSuffix=core.windows.net";
            string containerName = folderName;

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            BlobClient blobClient = containerClient.GetBlobClient(newFileName);

            if (files.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    files.CopyTo(ms);
                    ms.Position = 0;
                    await blobClient.UploadAsync(ms, true);
                }
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

        string connectionString = "DefaultEndpointsProtocol=https;AccountName=kmccfileupload;AccountKey=h+PFVsQg8A6A9S43/lDDABLNO6GyzGTmGRgH6op5KHwXo85jyBrD7XivcCtWvZvZJHNFIp84my43+AStWH/JCw==;EndpointSuffix=core.windows.net";
        string containerName = folderName;

        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        BlobClient blobClient = containerClient.GetBlobClient(fileName);
        using var stream = new MemoryStream();
        await blobClient.DownloadToAsync(stream);
        stream.Position = 0;

        return stream
    }
}