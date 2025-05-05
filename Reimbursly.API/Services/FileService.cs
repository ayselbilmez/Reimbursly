using Reimbursly.Application.Interfaces;

namespace Reimbursly.API.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _env;

    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> SaveReceiptAsync(IFormFile file)
    {
        var uploadsFolder = Path.Combine(_env.WebRootPath, "receipts");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/receipts/{fileName}";
    }
}
