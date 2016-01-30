using System;
using System.Windows.Forms;
using Core;
using Infrastructure.Modules;
using Ninject;

namespace UI.WinForms
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
            var kernel = new StandardKernel();
            kernel.Load(new PdfInserterModule());
            var pdfInserter = kernel.Get<IPdfInserter>();
            var mainForm = new InserterForm(pdfInserter);
            Application.Run(mainForm);
        }
    }
}
