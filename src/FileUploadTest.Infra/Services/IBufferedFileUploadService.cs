using Microsoft.AspNetCore.Http;

namespace FileUploadTest.Infra.Services;

public interface IBufferedFileUploadService
{
    Task<bool> UploadFile(IFormFile file);
}