using System;
using System.Windows.Forms;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.EntityFramework;

namespace LozhkinAA.TestTasks.Xrm.Annotations.Viewer
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //composition root
            var form = new MainForm(new AnnotationService(new AnnotattionsContext()));
            Application.Run(form);
        }
    }
}