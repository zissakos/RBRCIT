using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace RBRCIT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            
            try
            {
                Form1 f = new Form1();
                Application.Run(f);
                //Application.Run(new Form1());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception");
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //IMPORTANT: must return null if not handled here. 

            /*
            //load from subfolder
            string dllfile = new AssemblyName(args.Name).Name + ".dll";
            if (dllfile=="ObjectListView.dll")
            {
                string path = Application.StartupPath + "\\RBRCIT\\" + dllfile;
                return Assembly.LoadFile(path);
            }
            return null;
            */

            //load from exe file as a resource.
            //dll must be added to the project, Build Action: Embedded Resource


            //string[] res = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            string[] embeddedDLLs = new string[] { "ObjectListView.dll", "SharpCompress.dll" };
            string dllfile = new AssemblyName(args.Name).Name + ".dll";
            if (embeddedDLLs.Contains(dllfile))
            {
                String resourceName = "RBRCIT.embed." + dllfile;
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            }
            return null;


            
        }

    }
}
