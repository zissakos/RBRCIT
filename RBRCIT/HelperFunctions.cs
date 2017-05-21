using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RBRCIT
{
    public static class HelperFunctions
    {


        public static void AutoResizeByHeaderAndContent(ObjectListView olv)
        {
            foreach (OLVColumn col in olv.ColumnsInDisplayOrder)
            {
                int colWidthBeforeAutoResize = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int colWidthAfterAutoResizeByHeader = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int colWidthAfterAutoResizeByContent = col.Width;

                if (colWidthAfterAutoResizeByHeader > colWidthAfterAutoResizeByContent)
                    col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                col.Width += 1;
            }
        }

        //copies the content of sourcedir into destDir.
        public static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
        }

        /// <summary>
        /// deletes all the contents of the directory, leaving the directory intact
        /// </summary>
        /// <param name="path"></param>
        public static void DirectoryEmpty(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }


        public static void ShowAtCenterParent(this Form form, Form parent)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Top = (parent.Top + (parent.Height / 2)) - form.Height / 2;
            form.Left = (parent.Left + (parent.Width / 2)) - form.Width / 2;
            form.Show();
        }



    }
}
