using Microsoft.AspNetCore.Http;

namespace Reimbursly.Application.Interfaces;

public interface IFileService
{
    Task<string> SaveReceiptAsync(IFormFile file);
}
