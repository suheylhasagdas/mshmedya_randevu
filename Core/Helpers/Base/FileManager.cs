using Core.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Model.Response.Common;
using System.Collections.Generic;
using System.IO;

namespace Core.Helpers.Base
{
    public class FileManager : IFileService
    {
        public List<FileItem> GetFileRequest(List<IFormFile> model)
        {
            List<FileItem> response = new List<FileItem>();

            foreach (var item in model)
            {
                FileItem fr = new FileItem();
                fr.extension = Path.GetExtension(item.FileName);
                fr.OriginalFileName = item.FileName;
                fr.ContentType = item.ContentType;

                using (var ms = new MemoryStream())
                {
                    item.CopyTo(ms);
                    fr.InputStream = ms.ToArray();
                    fr.ContentLength = fr.InputStream.Length;
                }

                response.Add(fr);
            }

            return response;
        }

        public FileItem GetFileRequest(IFormFile model)
        {
            FileItem response = new FileItem();
            response.extension = Path.GetExtension(model.FileName);
            response.OriginalFileName = model.FileName;
            response.ContentType = model.ContentType;

            using (var ms = new MemoryStream())
            {
                model.CopyTo(ms);
                response.InputStream = ms.ToArray();
                response.ContentLength = response.InputStream.Length;
            }

            return response;
        }
        public bool DeleteFile(string path)
        {
            try
            {
                File.Delete($"{ Directory.GetCurrentDirectory()}/wwwroot/Files/{path}");
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public string SaveFile(IFormFile file)
        {
            string savePath = Path.Combine($"{ Directory.GetCurrentDirectory()}/wwwroot/Files/", file.FileName);
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string serverPath = $"/Files/{file.FileName}";
            return serverPath;
        }
    }
}
