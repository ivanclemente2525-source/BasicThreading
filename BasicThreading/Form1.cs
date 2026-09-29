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
            // Pagbukas ng Console Window
            AllocConsole();

            // Pilitin niya ang Console na ire-direct ang output para lumabas ang text
            Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

            Console.WriteLine("-Before starting thread-"); 

            // Gumawa ng Delegate para sa Thread1
            ThreadStart delThread = new ThreadStart(MyThreadClass.Thread1); 

            // Gumawa ng dalawang Child Threads
            Thread ThreadA = new Thread(delThread); 
            ThreadA.Name = "Thread A Process"; 

            Thread ThreadB = new Thread(delThread); 
            ThreadB.Name = "Thread B Process"; 

            // Simulan palang ang mga threads
            ThreadA.Start(); 
            ThreadB.Start(); 

            // Hihintayin niya matapos ang dalawang threads bago magpatuloy
            ThreadA.Join();
            ThreadB.Join(); 

            Console.WriteLine($"The thread 0x{ThreadA.ManagedThreadId:x} has exited with code 0 (0x0)."); 
            Console.WriteLine($"The thread 0x{ThreadB.ManagedThreadId:x} has exited with code 0 (0x0)."); 

            Console.WriteLine("-End of Thread-"); 

            lblStatus.Text = "-End of Thread-"; 
        }
    }
}