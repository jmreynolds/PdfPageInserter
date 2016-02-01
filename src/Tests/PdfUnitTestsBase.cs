using System.IO;
using Core;
using NUnit.Framework;
using Service;
using Should;

namespace Tests
{

    [TestFixture(typeof(PdfSharpPdfInserter), "PdfSharpOutput.pdf")]
    public class PdfUnitTests<TInserter> where TInserter : IPdfInserter, new()
    {
        private readonly string _outputFile;
        private string _currentPath = @"C:\Development\GoDirect\PdfPageInserter\TestFiles\";
        private readonly IPdfInserter _pdfInserter;

        public PdfUnitTests(string outputFile)
        {
            _outputFile = outputFile;
            _pdfInserter = new TInserter();
        }


        [Test]
        public void ShouldWriteSmallPdf()
        {
            var inputFile = $"{_currentPath}SampleSmallFile.pdf";
            var intervalToInsert = 3;
            var numberOfPagesInSequence = 5;
            var outputPath = $"{_currentPath}SampleSmall{_outputFile}";
            _pdfInserter.NumberOfPagesInSequence = numberOfPagesInSequence;
            _pdfInserter.IntervalToInsert = intervalToInsert;
            _pdfInserter.OutputPdfPath = outputPath;
            _pdfInserter.InputPath = inputFile;

            _pdfInserter.InsertPages();

            File.Exists(inputFile).ShouldBeTrue("input file doesn't exist");
            File.Exists(outputPath).ShouldBeTrue("output file doesn't exist");
            _pdfInserter.GetPageCount(inputFile).ShouldEqual(110);
            _pdfInserter.GetPageCount(outputPath).ShouldEqual(132);
        }

        [Test]
        public void ShouldWriteLargePdf()
        {
            var inputFile = $"{_currentPath}SampleLargeFile.pdf";
            var intervalToInsert = 3;
            var numberOfPagesInSequence = 5;
            var outputPath = $"{_currentPath}SampleLarge{_outputFile}";
            _pdfInserter.NumberOfPagesInSequence = numberOfPagesInSequence;
            _pdfInserter.IntervalToInsert = intervalToInsert;
            _pdfInserter.OutputPdfPath = outputPath;
            _pdfInserter.InputPath = inputFile;

            _pdfInserter.InsertPages();

            File.Exists(inputFile).ShouldBeTrue("input file doesn't exist");
            File.Exists(outputPath).ShouldBeTrue("output file doesn't exist");
            _pdfInserter.GetPageCount(inputFile).ShouldEqual(5000);
            _pdfInserter.GetPageCount(outputPath).ShouldEqual(6000);
        }

        //[TearDown]
        //public void CleanUp()
        //{
        //    if (File.Exists($"{_currentPath}SampleLargeOutput.pdf"))
        //    {
        //        File.Delete($"{_currentPath}SampleLargeOutput.pdf");
        //    }

        //    if (File.Exists($"{_currentPath}SampleSmallOutput.pdf"))
        //    {
        //        File.Delete($"{_currentPath}SampleSmallOutput.pdf");
        //    }
        //}
    }
}