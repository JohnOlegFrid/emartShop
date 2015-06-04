using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using BL;


namespace PL
{
    /// <summary>
    /// Logique d'interaction pour ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar : Window
    {
        BL_Manager bl_manager;

        public bool finished;
        public ProgressBar(BL_Manager bl_manager)
        {
            InitializeComponent();
            this.bl_manager = bl_manager;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            finished = false;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {


            for (int i = 0; i < 101; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(3);
            }
            finished = true;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Boolean endOfTask()
        {
            return finished;
        }



    }
}

