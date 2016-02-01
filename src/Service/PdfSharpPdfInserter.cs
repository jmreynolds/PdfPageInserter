using System;
using System.IO;
using Core;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Service
{
    public class PdfSharpPdfInserter : IPdfInserter
    {
        private string _inputPath;

        public string InputPath
        {
            get { return _inputPath; }
            set
            {
                _inputPath = value;
                InputPathChanged?.Invoke(this, new EventArgs());
            }
        }
        public event EventHandler InputPathChanged;
        public int NumberOfPagesInSequence { get; set; }
        public int IntervalToInsert { get; set; }
        public string OutputPdfPath { get; set; }
        public void InsertPages()
        {
            PdfDocument document = PdfReader.Open(InputPath);

            int pageCounter = 0;

            for (int i = 0; i < document.PageCount; i++)
            {
                if (pageCounter == IntervalToInsert)
                {
                    document.InsertPage(i);
                }

                if (pageCounter == NumberOfPagesInSequence) pageCounter = 0;
                else pageCounter++;
            }
            document.Save(OutputPdfPath);
        }

        public int GetPageCount(string pdfFile)
        {
            PdfDocument document = PdfReader.Open(pdfFile);
            return document.PageCount;
        }
    }
}