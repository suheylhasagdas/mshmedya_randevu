using Microsoft.AspNetCore.Http;
using Model.Response.Common;
using System.Collections.Generic;

namespace Core.Helpers.Abstract
{
    public interface IFileService
    {
        List<FileItem> GetFileRequest(List<IFormFile> model);
        FileItem GetFileRequest(IFormFile model);

        string SaveFile(IFormFile file);
        bool DeleteFile(string path);
    }
}
