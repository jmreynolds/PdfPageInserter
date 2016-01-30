using Core;

namespace Service
{
    public class PdfInserter : IPdfInserter
    {
        public string OriginalPdfPath { get; set; }
        public int NumberOfPagesInSequence { get; set; }
        public int IntervalToInsert { get; set; }
        public string OutputPdfPath { get; set; }
        public void InsertPages(string originalPdfPath, int numberOfPagesInSequence, int intervalToInsert, string outputPdfPath)
        {
            throw new System.NotImplementedException();
        }
    }
}