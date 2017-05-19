using System.IO;
using SharpCompress.Common;
using SharpCompress.Archive;
using SharpCompress.Archive.Zip;

namespace RBRCIT
{
    class ZipManager
    {

        public static void ExtractToDirectory(string pathToZipFile, string extractToDir)
        {
            ArchiveFactory.WriteToDirectory(pathToZipFile, extractToDir, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite | ExtractOptions.PreserveFileTime);
        }

        public static void CreateFromDirectory(string sourceDir, string pathToZipFile, bool includeSourceDir)
        {
            ZipArchive za = ZipArchive.Create();
            DirectoryInfo di = new DirectoryInfo(sourceDir);
            FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);
            if (includeSourceDir) di = di.Parent;
            foreach (FileInfo fi in files)
            {
                za.AddEntry(fi.FullName.Replace(di.FullName, ""), fi.FullName);
            }
            za.SaveTo(pathToZipFile, CompressionType.Deflate);
            za.Dispose();
        }

    }
}
