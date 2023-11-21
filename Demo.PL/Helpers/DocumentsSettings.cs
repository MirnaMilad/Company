using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.IO;

namespace Demo.PL.Helpers
{
    public static class DocumentsSettings
    {
        //Upload
        public static string UploadFile(IFormFile file , string FolderName)
        {
            //1.Get Located Folder Path
            //string FolderPath = Directory.GetCurrentDirectory() + "\\wwwroot\\Files\\" + FolderName;
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Files" , FolderName);
            //2.Get File Name and Make it Unique
            string FileName = $"{Guid.NewGuid() + file.FileName}";
            //3.Get File Path[Folder Path + FileName]
            string FilePath = Path.Combine(FolderPath, FileName);
            //4.Save File As Streams
            using var Fs = new FileStream(FilePath , FileMode.Create);
            file.CopyTo(Fs);
            //5.Return File Name
            return FileName;
        }
        //Delete

        public static void DeleteFile (string FileName, string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Files", FolderName);
            string FilePath = Path.Combine(FolderPath, FileName);
            if(File.Exists(FilePath))
            {
            File.Delete(FilePath);
            }
        }

    }
}
