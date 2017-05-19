using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace RBRCIT
{
    enum LineType
    {
        empty, comment, section, parameter
    }

    [DebuggerDisplay("{type}, {section}, {parameter}, {value}, {comment}")]
    struct LineEntry
    {
        public LineType type;
        public string section;
        public string parameter;
        public string value;
        public string comment;
    }

    public class INIFile
    {
        public bool SpaceBeforeAndAfterEquals = true;
        
        List<LineEntry> lines;
        private string filepath;

        public INIFile()
        {
            lines = new List<LineEntry>();
        }

        public INIFile(string path)
            : this()
        {
            LoadFile(path);
        }

        public void LoadFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Unable to locate " + path);
            filepath = path;
            StreamReader reader = new StreamReader(path);
            string line;
            string currentSection = null;
            while (!reader.EndOfStream)
            {
                LineEntry lineEntry = new LineEntry();
                line = reader.ReadLine().Trim();
                if (line.Length == 0)
                {
                    lineEntry.type = LineType.empty;
                }
                else if (IsComment(line))
                {
                    lineEntry.type = LineType.comment;
                    lineEntry.comment = line;
                }
                else if (IsSectionName(line))
                {
                    lineEntry.type = LineType.section;
                    lineEntry.section = line.Substring(1, line.Length - 2);
                    currentSection = lineEntry.section;
                }
                else if (IsParameterDefinition(line))
                {
                    int offset = line.IndexOf("=");
                    string value = null;
                    if (line.Length > offset + 1) value = line.Substring(offset + 1).Trim();

                    lineEntry.type = LineType.parameter;
                    lineEntry.section = currentSection;
                    lineEntry.parameter = line.Substring(0, offset).Trim();
                    lineEntry.value = value;
                }
                lines.Add(lineEntry);
            }
            reader.Close();
        }

        private bool IsComment(string line)
        {
            return line.StartsWith("#") || line.StartsWith("//") || line.StartsWith(";");
        }

        private bool IsSectionName(string line)
        {
            return line.StartsWith("[") && line.EndsWith("]");
        }

        private bool IsParameterDefinition(string line)
        {
            return line.Contains("=");
        }


        public string GetCommentAtLine(int line_nr)
        {
            if (line_nr >= lines.Count) return null;
            return lines[line_nr].comment;
        }

        public List<string> GetSections()
        {
            List<LineEntry> list = lines.FindAll(x => x.type == LineType.section);
            List<string> result = new List<string>();
            foreach (LineEntry le in list) result.Add(le.section);
            return result;
        }

        public List<string> GetParameterNames(string SectionName = null)
        {
            List<LineEntry> list = lines.FindAll(x => x.type == LineType.parameter && x.section == SectionName);
            List<string> result = new List<string>();
            foreach (LineEntry le in list) result.Add(le.parameter);
            return result;
        }

        public string GetParameterValue(string ParameterName, string SectionName = null)
        {
            LineEntry le = lines.Find(x => x.type == LineType.parameter && x.section == SectionName && x.parameter == ParameterName);
            return le.value;
        }

        public int GetParameterValueInt(string ParameterName, string SectionName = null)
        {
            return int.Parse(GetParameterValue(ParameterName, SectionName));
        }

        public bool GetParameterValueBool(string ParameterName, string SectionName = null)
        {
            string value = GetParameterValue(ParameterName, SectionName);
            if (value == null) return false;
            return bool.Parse(value);
        }

        public float GetParameterValueFloat(string ParameterName, string SectionName = null)
        {
            return float.Parse(GetParameterValue(ParameterName, SectionName));
        }

        public T GetParameterValueEnum<T>(string ParameterName, string SectionName = null)
        {
            string value = GetParameterValue(ParameterName, SectionName);
            return (T)Enum.Parse(typeof(T), value);
        }

        public bool SectionExists(string SectionName)
        {
            if (SectionName == null) return true;
            int index = lines.FindIndex(x => x.type == LineType.section && x.section != null && x.section == SectionName);
            return (index != -1);
        }

        public bool ParameterExists(string ParameterName, string SectionName = null)
        {
            int index = lines.FindIndex(x => x.type == LineType.parameter && x.section == SectionName && x.parameter == ParameterName);
            return (index != -1);
        }

        int ParameterIndex(string ParameterName, string SectionName = null)
        {
            return lines.FindIndex(x => x.type == LineType.parameter && x.section == SectionName && x.parameter == ParameterName);
        }

        public void AddSection(string SectionName)
        {
            if (SectionExists(SectionName)) return;
            LineEntry section = new LineEntry();
            section.type = LineType.section;
            section.section = SectionName;
            lines.Add(section);
        }

        public void AddParameter(string ParameterName, string Value = null, string SectionName = null)
        {
            if (!SectionExists(SectionName)) return;
            if (ParameterExists(ParameterName, SectionName)) return;
            LineEntry le = new LineEntry();
            le.type = LineType.parameter;
            le.section = SectionName;
            le.parameter = ParameterName;
            le.value = Value;
            lines.Insert(getIndexForNewParameter(SectionName), le);
        }

        int getIndexForNewParameter(string SectionName)
        {
            int index = lines.FindIndex(x => x.type == LineType.section && x.section == SectionName) + 1;
            if (index >= lines.Count) return index;

            //go forward until you find the next section or EOF
            while (lines[index].type != LineType.section && index < lines.Count - 1) index++;

            //go back to skip any empty lines
            int index2 = index - 1;
            while (lines[index2].type == LineType.empty) index2--;

            //if we are back at the section name, there are no empty lines in that section
            if (lines[index2].type == LineType.section) index2 = index;

            return index2 + 1;
        }

        public void ChangeParameter(string ParameterName, string Value = null, string SectionName = null)
        {
            if (!ParameterExists(ParameterName, SectionName)) return;
            int index = ParameterIndex(ParameterName, SectionName);
            LineEntry le = lines[index];
            le.value = Value;
            lines[index] = le;
        }

        public void DeleteParameter(string ParameterName, string SectionName = null)
        {
            lines.RemoveAll(x => x.type == LineType.parameter && x.section == SectionName && x.parameter == ParameterName);
        }

        //adds a param (and section) if it does not exist, otherwise changes it
        public void AddOrChangeParameter(string ParameterName, string Value = null, string SectionName = null)
        {
            if (!SectionExists(SectionName)) AddSection(SectionName);
            if (!ParameterExists(ParameterName, SectionName))
                AddParameter(ParameterName, Value, SectionName);
            else
                ChangeParameter(ParameterName, Value, SectionName);
        }

        public void SaveAs(string path)
        {
            string equals = "=";
            if (SpaceBeforeAndAfterEquals) equals = " = ";
            StreamWriter writer = new StreamWriter(path, false);
            foreach (LineEntry le in lines)
            {
                switch (le.type)
                {
                    case LineType.empty: 
                        writer.WriteLine();
                        break;
                    case LineType.comment:
                        writer.WriteLine(le.comment);
                        break;
                    case LineType.section:
                        writer.WriteLine( "[" + le.section + "]");
                        break;
                    case LineType.parameter:
                        string output = le.parameter + equals;
                        if (le.value != null) output += le.value;
                        writer.WriteLine(output);
                        break;
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
