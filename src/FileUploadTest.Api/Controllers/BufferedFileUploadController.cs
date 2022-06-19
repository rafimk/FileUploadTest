using FileUploadTest.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BufferedFileUploadController : ControllerBase
{
    readonly IBufferedFileUploadService _bufferedFileUploadService;
    public BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService)
    {
        _bufferedFileUploadService = bufferedFileUploadService;
    }

    [HttpPost]
    public async Task<ActionResult> Index(IFormFile file)
    {
        string message = "";
        try
        {
            if (await _bufferedFileUploadService.UploadFile(file))
            {
                message = "File Upload Successful";
            }
            else
            {
                message = "File Upload Failed";
            }
        }
        catch (Exception ex)
        {
            //Log ex
            message = "File Upload Failed";
        }
        return Ok(message);
    }
}