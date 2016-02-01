using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace UI.WinForms
{
    public partial class InserterForm : Form
    {
        private readonly IPdfInserter _pdfInserter;

        public InserterForm(IPdfInserter pdfInserter)
        {
            _pdfInserter = pdfInserter;
            _pdfInserter.InputPathChanged += OnInputPathChanged;
            InitializeComponent();
        }

        private void OnInputPathChanged(object sender, EventArgs args)
        {
            tbInputFileName.Text = _pdfInserter.InputPath;
            _pdfInserter.OutputPdfPath = _pdfInserter.InputPath.Replace(".pdf", "_Fixed.pdf");
            tbOutputFileName.Text = _pdfInserter.OutputPdfPath;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            lblComplete.Visible = false;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var inputPath = openFileDialog1.FileName;
                _pdfInserter.InputPath = inputPath;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(tbIncrement.Text, out i))
            {
                _pdfInserter.IntervalToInsert = i;
            }
            else
            {
                lblComplete.Text = "Please enter a numeric number for the blank page.";
                lblComplete.Visible = true;
                tbIncrement.Focus();
                return;
            }
            if (int.TryParse(tbSequenceCount.Text, out i))
            {
                _pdfInserter.NumberOfPagesInSequence = i;
            }
            else
            {
                lblComplete.Text = "Please enter a numeric number for the statement page count.";
                lblComplete.Visible = true;
                tbSequenceCount.Focus();
                return;
            }

            if (_pdfInserter.InputPath == string.Empty)
            {
                lblComplete.Text = "Please select an input path.";
                lblComplete.Visible = true;
                btnBrowse.Focus();
                return;
            }

            _pdfInserter.InsertPages();
            int oldPageCount = _pdfInserter.GetPageCount(_pdfInserter.InputPath);
            int newPageCount = _pdfInserter.GetPageCount(_pdfInserter.OutputPdfPath);
            lblComplete.Text = $"Complete.{Environment.NewLine}" +
                               $"Old file had {oldPageCount} pages.{Environment.NewLine}" +
                               $"New File has {newPageCount} pages.";
            lblComplete.Visible = true;
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
    }
}
