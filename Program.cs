using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Realms;

namespace WindowsFormsApp3
{
    public class Program
    {
        public static Form1 f1 { get; private set; }
        public static Form2 f2 { get; private set; }
        public static Form3 f3 { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.f1 = new Form1();
            Program.f1.StartPosition = FormStartPosition.CenterScreen;
            Program.f2 = new Form2();
            Program.f2.StartPosition = FormStartPosition.CenterScreen;
            Program.f3 = new Form3();
            Program.f3.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(Program.f1);

        }
    }
}