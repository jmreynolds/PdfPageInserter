using System;
using System.IO;
using Core;
using NUnit.Framework;
using Service;
using Should;

namespace Tests
{
    [TestFixture]
    public class UnitTests
    {
        private string _currentPath = @"C:\Development\GoDirect\PdfPageInserter\TestFiles\";

        [Test]
        public void ShouldWriteSmallPdf()
        {
            var inputFile = $"{_currentPath}SampleSmallFile.pdf";
            var intervalToInsert = 3;
            var numberOfPagesInSequence = 5;
            var outputPath = $"{_currentPath}SampleSmallOutput.pdf";
            IPdfInserter pdfInserter = 
                new PdfInserter
                {
                    InputPath = inputFile,
                    OutputPdfPath = outputPath,
                    IntervalToInsert = intervalToInsert,
                    NumberOfPagesInSequence = numberOfPagesInSequence
                };

            pdfInserter.InsertPages();

            File.Exists(inputFile).ShouldBeTrue("input file doesn't exist");
            File.Exists(outputPath).ShouldBeTrue("output file doesn't exist");
            pdfInserter.GetPageCount(inputFile).ShouldEqual(110);
            pdfInserter.GetPageCount(outputPath).ShouldEqual(132);
        }

        [Test]
        public void ShouldWriteLargePdf()
        {
            var inputFile = $"{_currentPath}SampleLargeFile.pdf";
            var intervalToInsert = 3;
            var numberOfPagesInSequence = 5;
            var outputPath = $"{_currentPath}SampleLargeOutput.pdf";
            IPdfInserter pdfInserter =
                new PdfInserter
                {
                    InputPath = inputFile,
                    OutputPdfPath = outputPath,
                    IntervalToInsert = intervalToInsert,
                    NumberOfPagesInSequence = numberOfPagesInSequence
                };

            pdfInserter.InsertPages();

            File.Exists(inputFile).ShouldBeTrue("input file doesn't exist");
            File.Exists(outputPath).ShouldBeTrue("output file doesn't exist");
            pdfInserter.GetPageCount(inputFile).ShouldEqual(5000);
            pdfInserter.GetPageCount(outputPath).ShouldEqual(6000);
        }

        [TearDown]
        public void CleanUp()
        {
            var outputPath = $"{_currentPath}SampleOutput.pdf";
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }
    }
}
