using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RBRCIT
{
    public class FilePatcher
    {
        string filepath;
        MemoryStream mstream;

        public FilePatcher(string filename)
        {
            this.filepath = filename;
            FileStream infile = new FileStream(filename, FileMode.Open);
            FileInfo fi = new FileInfo(filename);
            byte[] buffer = new byte[fi.Length];
            infile.Read(buffer, 0, (int)fi.Length);
            infile.Close();
            mstream = new MemoryStream(buffer);
        }

        public void WriteAt(int address, int maxlength, string s)
        {
            mstream.Seek(address, SeekOrigin.Begin);
            for (int i = 0; i < maxlength; i++)
            {
                if (i < s.Length) mstream.WriteByte((byte)s[i]);
                else mstream.WriteByte(0); //fill with 0-byte to overwrite previous values
            }
        }

        public void SaveAs(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            mstream.WriteTo(fs);
            fs.Close();
        }

        public void Save()
        {
            SaveAs(filepath);
        }

    }
}
