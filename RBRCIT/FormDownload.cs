using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;
using System.IO;
using System.Net.Mime;

namespace RBRCIT
{

    public struct DownloadJob
    {
        public string title;
        public string URL;
        public string path;
    }

    public partial class FormDownload : Form
    {
        public string filename;
        public List<DownloadJob> jobQueue;
        int currentJob;
        int totalJobs;
        private RBRCITModel rbrcit;

        public FormDownload(List<DownloadJob> jobs, RBRCITModel model)
        {
            InitializeComponent();
            jobQueue = new List<DownloadJob>(jobs);
            currentJob = 0;
            totalJobs = jobQueue.Count;
            rbrcit = model;
            downloadNextJob();
        }

        public FormDownload(DownloadJob job, RBRCITModel model) : this (new List<DownloadJob>() { job }, model)
        {
        }


        void downloadNextJob()
        {
            if (jobQueue.Count > 0)
            {
                DownloadJob job = jobQueue[jobQueue.Count - 1];
                currentJob++;
                label1.Text = job.title + " (" + currentJob + " of " + totalJobs + " Files)";
                label3.Text = job.URL.Replace("%20", " ");
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadDataCompleted += Client_DownloadDataCompleted;
                    Uri u = new Uri(job.URL);
                    client.DownloadDataAsync(u, client);
                }
            }
            else
            {
                Close();
            }
        }

        string getFileNameFromURL(string url)
        {
            string[] chunks = url.Split('/');
            string result = chunks[chunks.Length - 1];  //return the last part (after the last '/')
            return result;
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                Close();
                return;
            }

            DownloadJob job = jobQueue[jobQueue.Count - 1];
            /*
            WebClient wc = (WebClient)e.UserState;
            string header_contentDisposition = wc.ResponseHeaders["content-disposition"];
            filename = job.path + new ContentDisposition(header_contentDisposition).FileName;
            */
            filename = getFileNameFromURL(job.URL);

            FileStream fs = new FileStream(filename, FileMode.Create);
            fs.Write(e.Result, 0, e.Result.Length);
            fs.Close();

            //ZipManager.ExtractToDirectory(filename, job.path);
            rbrcit.ExtractFile(filename, job.path);

            File.Delete(filename);
            jobQueue.RemoveAt(jobQueue.Count - 1);
            downloadNextJob();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label2.Text = "Downloaded: " + e.BytesReceived + " of " + e.TotalBytesToReceive + " Bytes";
            progressBar1.Value = e.ProgressPercentage;
        }



    }
}
