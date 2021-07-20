using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FilesApp
{
    public static class FolderManager
    {
        public static bool CreateFolder(string newFolderPath)
        {
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
                return true;
            }
            return false;
        }

        public static bool CopyFolder(string sourceFolderPath, string destinyFolderPath)
        {
            DirectoryInfo sourceFolder = new DirectoryInfo(sourceFolderPath);
            if (sourceFolder.Exists)
            {
                DirectoryInfo[] sourceSubFolders = sourceFolder.GetDirectories();
                if (!Directory.Exists(destinyFolderPath))
                {
                    Directory.CreateDirectory(destinyFolderPath);
                }
                FileInfo[] sourceFiles = sourceFolder.GetFiles();
                foreach (FileInfo file in sourceFiles)
                {
                    string temppath = Path.Combine(destinyFolderPath, file.Name);
                    file.CopyTo(temppath, false);
                }
                foreach (DirectoryInfo folder in sourceSubFolders)
                {
                    string temppath = Path.Combine(destinyFolderPath, folder.Name);
                    CopyFolder(folder.FullName, temppath);
                }
                return true;
            }
            return false;
        }

        public static bool MoveFolder(string sourceFolderPath, string newFolderPath)
        {
            if (Directory.Exists(sourceFolderPath))
            {
                Directory.Move(sourceFolderPath, newFolderPath);
                return true;
            }
            return false;
        }

        public static bool DeleteFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath);
                return true;
            }
            return false;
        }
    }
}
