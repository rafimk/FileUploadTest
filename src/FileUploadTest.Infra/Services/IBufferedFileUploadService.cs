﻿using Microsoft.AspNetCore.Http;

namespace FileUploadTest.Infra.Services;

public interface IBufferedFileUploadService
{
    Task<Guid?> UploadFile(IFormFile file);

    Task<MemoryStream> Download(Guid fileGuid, string fileName, string filePath);
}