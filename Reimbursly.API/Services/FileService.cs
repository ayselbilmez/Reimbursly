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
        if (file == null || file.Length == 0)
            throw new ArgumentException("Document cannot be saved.");

        if (string.IsNullOrEmpty(_env.WebRootPath))
            throw new InvalidOperationException("WebRootPath is not set. Make sure wwwroot folder exists.");

        var uploadsFolder = Path.Combine(_env.WebRootPath, "receipts");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/receipts/{fileName}";
    }
}
