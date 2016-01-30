using System;
using System.IO;
using Core;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Service
{
    public class PdfInserter : IPdfInserter
    {

        public string InputPath { get; set; }
        public int NumberOfPagesInSequence { get; set; }
        public int IntervalToInsert { get; set; }
        public string OutputPdfPath { get; set; }

        public void InsertPages()
        {
            if (InputPath == string.Empty)
                throw new ArgumentException("No input path defined");
            if (OutputPdfPath == string.Empty)
                throw new ArgumentException("No output path defined");
            if (IntervalToInsert == 0)
                throw new ArgumentException("Insert Interval is not set");
            if (NumberOfPagesInSequence == 0)
                throw new ArgumentException("Number of Pages is not set");

            PdfReader reader = new PdfReader(InputPath);
            Rectangle pagesize = GetPageSize(reader, 1);
            Document document = new Document(pagesize);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(OutputPdfPath, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;

            // This will increment
            // every time it hits the number in sequence, it should reset
            // when it hits the interval to insert, we should insert a page
            int pageCounter = 1;

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                pagesize = GetPageSize(reader, i);
                document.SetPageSize(pagesize);
                document.NewPage();
                var page = writer.GetImportedPage(reader, i);
                cb.AddTemplate(page, 0, 0);

                if (pageCounter == IntervalToInsert)
                {
                    document.NewPage();
                    writer.PageEmpty = false;
                }

                if (pageCounter == NumberOfPagesInSequence) pageCounter = 1;
                else pageCounter++;
            }
            document.Close();
            reader.Close();
        }

        public int GetPageCount(string pdfFile)
        {
            if (InputPath == string.Empty)
                throw new ArgumentException("No input path defined");
            PdfReader reader = new PdfReader(pdfFile);

            return reader.NumberOfPages;
        }

        private Rectangle GetPageSize(PdfReader reader, int i)
        {
            Rectangle pagesize = reader.GetPageSizeWithRotation(1);
            return 
                new Rectangle(Math.Min(pagesize.Width, pagesize.Height),
                    Math.Max(pagesize.Width, pagesize.Height));
        }


    }
}