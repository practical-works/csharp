using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FilesApp
{
    public static class FileManager
    {
        public static bool CreateFile(string newFilePath)
        {
            if (!File.Exists(newFilePath))
            {
                File.WriteAllText(newFilePath, "This is an empty file");
                return true;
            }
            return false;
        }

        public static bool CopyFile(string sourceFilePath, string destinyFilePath)
        {
            DirectoryInfo sourceFolder = new DirectoryInfo(sourceFilePath);
            if (sourceFolder.Exists)
            {
                DirectoryInfo[] sourceSubFolders = sourceFolder.GetDirectories();
                if (!Directory.Exists(destinyFilePath))
                {
                    Directory.CreateDirectory(destinyFilePath);
                }
                FileInfo[] sourceFiles = sourceFolder.GetFiles();
                foreach (FileInfo file in sourceFiles)
                {
                    string temppath = Path.Combine(destinyFilePath, file.Name);
                    file.CopyTo(temppath, false);
                }
                foreach (DirectoryInfo folder in sourceSubFolders)
                {
                    string temppath = Path.Combine(destinyFilePath, folder.Name);
                    CopyFile(folder.FullName, temppath);
                }
                return true;
            }
            return false;
        }

        public static bool MoveFile(string sourceFilePath, string newFilePath)
        {
            if (Directory.Exists(sourceFilePath))
            {
                Directory.Move(sourceFilePath, newFilePath);
                return true;
            }
            return false;
        }

        public static bool DeleteFile(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
