using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BasicThreading
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // To open Console Window
            AllocConsole();

            Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

            Console.WriteLine("-Before starting thread-"); 

            ThreadStart delThread = new ThreadStart(MyThreadClass.Thread1); 

            Thread ThreadA = new Thread(delThread); 
            ThreadA.Name = "Thread A Process"; 

            Thread ThreadB = new Thread(delThread); 
            ThreadB.Name = "Thread B Process"; 

            ThreadA.Start(); 
            ThreadB.Start(); 

            ThreadA.Join();
            ThreadB.Join(); 

            Console.WriteLine("-End of Thread-"); 

            lblStatus.Text = "-End of Thread-"; 
        }
    }
}
