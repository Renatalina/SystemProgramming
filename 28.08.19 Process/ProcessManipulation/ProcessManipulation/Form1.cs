using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManipulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string file = new FileInfo(Application.ExecutablePath).Name;
            string[] files = Directory.GetFiles(Application.StartupPath, "*.exe");

            foreach (var item in files)
            {
                string fileName = new FileInfo(item).Name.Replace(".exe", "");
                if (file.Contains(fileName) == false)
                {
                    lstAvailable.Items.Add(fileName);
                }
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ListBox).Name == nameof(lstAvailable))
            {
                btnStart.Enabled = lstAvailable.SelectedItem != null ? true : false;
            }
            else if ((sender as ListBox).Name == nameof(lstStarted))
            {
                if (lstStarted.SelectedIndex != -1)
                {
                    btnStop.Enabled = true;
                    btnClose.Enabled = true;
                }
                else
                {
                    btnStop.Enabled = false;
                    btnClose.Enabled = false;
                }
            }
        }

        delegate void ProcessDelegate(Process process);

        void OnExecuteDelegate(string name, ProcessDelegate processDelegate)
        {
            Process[] processes = Process.GetProcessesByName(name);

            foreach (Process item in processes)
            {
                processDelegate(item);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            OnExecuteDelegate(lstStarted.SelectedItem.ToString(), ProcessKill);
        }

        void ProcessKill(Process process)
        {
            process.Kill();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnExecuteDelegate(lstStarted.SelectedItem.ToString(), CloseWindow);
        }

        void CloseWindow(Process process)
        {
            process.CloseMainWindow();
        }

        List<Process> _processes = new List<Process>();

        private void btnStart_Click(object sender, EventArgs e)
        {
            Process process = Process.Start(lstAvailable.SelectedItem.ToString());

            _processes.Add(process);

            process.EnableRaisingEvents = true;

            process.Exited += Process_Exited;

            if (lstStarted.Items.Contains(process.ProcessName) == false)
            {
                lstStarted.Items.Add(process.ProcessName);
            }
            lstAvailable.Items.Remove(lstAvailable.SelectedItem);
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            try
            {
                Process process = sender as Process;

                lstStarted.Items.Remove(process.ProcessName);
                lstAvailable.Items.Add(process.ProcessName);

                _processes.Remove(process);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in _processes)
            {
                item.Kill();
            }
        }
    }
}
