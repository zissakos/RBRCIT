using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace RBRCIT 
{
    [DebuggerDisplay("{section}, {parameter}, {value}, {comment}")]
    struct LineEntry
    {
        public string section;
        public string parameter;
        public string value;
        public string comment;
    }

    public class INIFile
    {
        public bool SpaceBeforeAndAfterEquals = true;

        List<LineEntry> lines;
        List<string> sections;
        string filepath;

        public INIFile()
        {
            lines = new List<LineEntry>();
            sections = new List<string>();
        }

        public INIFile(string path)
            : this()
        {
            LoadFile(path);
        }

        void parseComment(string line, out string comment, out string lineWithoutComment)
        {
            comment = null;
            lineWithoutComment = line;

            int i = 0;
            i = line.IndexOf(";");
            if (i < 0) i = line.IndexOf("#");
            if (i < 0) return;

            comment = line.Substring(i);
            lineWithoutComment = line.Substring(0, i);
            return;
        }

        void parseSectionName(string line, out string section)
        {
            section = null;
            int a = line.IndexOf("[");
            int b = line.IndexOf("]");
            if ((a >= 0) && (b >= 0) && (b >= a)) section = line.Substring(a + 1, b - a - 1);
            return;
        }

        void parseParameterAndValue(string line, out string parameter, out string value)
        {
            parameter = null;
            value = null;
            int i = line.IndexOf("=");
            if (i >= 0)
            {
                parameter = line.Substring(0, i).Trim();
                if (line.Length > i + 1) value = line.Substring(i + 1).Trim();
            }
            return;
        }

        void LoadFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Unable to locate " + path);
            filepath = path;
            StreamReader reader = new StreamReader(path);
            string line, lineWithoutComment;
            string currentSection = null;
            while (!reader.EndOfStream)
            {
                LineEntry lineEntry = new LineEntry();
                line = reader.ReadLine().Trim();

                parseComment(line, out lineEntry.comment, out lineWithoutComment);

                parseSectionName(lineWithoutComment, out lineEntry.section);
                if (lineEntry.section != null)
                {
                    currentSection = lineEntry.section;
                    sections.Add(lineEntry.section);
                }

                parseParameterAndValue(lineWithoutComment, out lineEntry.parameter, out lineEntry.value);
                if (lineEntry.parameter != null) lineEntry.section = currentSection;

                lines.Add(lineEntry);
            }
            reader.Close();
        }

        public string GetCommentAtLine(int line_nr)
        {
            if (line_nr >= lines.Count) return null;
            return lines[line_nr].comment;
        }

        public List<string> GetSections()
        {
            return sections;
        }

        List<string> getParameterNames(string SectionName)
        {
            List<LineEntry> list = lines.FindAll(x => x.section == SectionName && x.parameter != null);
            List<string> result = new List<string>();
            foreach (LineEntry le in list) result.Add(le.parameter);
            return result;
        }

        public string GetParameterValue(string ParameterName, string SectionName)
        {
            LineEntry le = lines.Find(x => x.section == SectionName && x.parameter == ParameterName);
            return le.value;
        }

        public int GetParameterValueInt(string ParameterName, string SectionName)
        {
            return int.Parse(GetParameterValue(ParameterName, SectionName));
        }

        public bool GetParameterValueBool(string ParameterName, string SectionName)
        {
            string value = GetParameterValue(ParameterName, SectionName);
            if (value == null) return false;
            return bool.Parse(value);
        }

        public float GetParameterValueFloat(string ParameterName, string SectionName)
        {
            return float.Parse(GetParameterValue(ParameterName, SectionName));
        }

        public T GetParameterValueEnum<T>(string ParameterName, string SectionName)
        {
            string value = GetParameterValue(ParameterName, SectionName);
            return (T)Enum.Parse(typeof(T), value);
        }

        bool SectionExists(string SectionName)
        {
            return sections.Contains(SectionName);
        }

        bool ParameterExists(string ParameterName, string SectionName)
        {
            int index = lines.FindIndex(x => x.section == SectionName && x.parameter == ParameterName);
            return (index != -1);
        }

        //adds a section at the end of the file
        void addSection(string SectionName)
        {
            LineEntry le = new LineEntry();
            le.section = SectionName;
            lines.Add(le);
            sections.Add(SectionName);
        }

        //adds a parameter to an existing section right after the section definition (as the first param of the section)
        void addParameter(string ParameterName, string Value, string SectionName)
        {
            LineEntry le = new LineEntry();
            le.section = SectionName;
            le.parameter = ParameterName;
            le.value = Value;
            int index = lines.FindIndex(x => x.section == SectionName && x.parameter == null && x.value == null) + 1;
            lines.Insert(index, le);
        }

        void changeParameter(string ParameterName, string Value, string SectionName)
        {
            int index = lines.FindIndex(x => x.section == SectionName && x.parameter == ParameterName);
            LineEntry le = lines[index];
            le.value = Value;
            lines[index] = le;
        }

        //adds a param (and section) if it does not exist, otherwise changes it
        public void SetParameter(string ParameterName, string Value, string SectionName)
        {
            if (!SectionExists(SectionName))
                addSection(SectionName);
            if (!ParameterExists(ParameterName, SectionName))
                addParameter(ParameterName, Value, SectionName);
            else
                changeParameter(ParameterName, Value, SectionName);
        }

        public void DeleteParameter(string ParameterName, string SectionName)
        {
            lines.RemoveAll(x => x.section == SectionName && x.parameter == ParameterName);
        }

        public void SaveAs(string path)
        {
            string equals = "=";
            if (SpaceBeforeAndAfterEquals) equals = " = ";
            StreamWriter writer = new StreamWriter(path, false);
            foreach (LineEntry le in lines)
            {
                if (le.section == null && le.parameter == null && le.value == null)
                    writer.WriteLine(le.comment);

                if (le.section != null && le.parameter == null && le.value == null)
                {
                    writer.Write("[" + le.section + "]");
                    if (le.comment != null) writer.WriteLine(" " + le.comment); else writer.WriteLine();
                }

                if (le.section != null && le.parameter != null)
                {
                    writer.Write(le.parameter + equals + le.value);
                    if (le.comment != null) writer.WriteLine(" " + le.comment); else writer.WriteLine();
                }
            }
            writer.Close();
        }
        
        public void Save()
        {
            SaveAs(filepath);
        }


    }
}
