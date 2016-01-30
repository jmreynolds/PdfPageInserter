﻿using System.Runtime.InteropServices;

namespace Core
{
    public interface IPdfInserter
    {
        string OriginalPdfPath { get; set; }
        int NumberOfPagesInSequence { get; set; }
        int IntervalToInsert { get; set; }
        string OutputPdfPath { get; set; }
        /// <summary>
        /// This method is used to insert the Pages.
        /// </summary>
        /// <param name="originalPdfPath">Should be a fully defined path to a PDF. Currently not supporting Network Paths.</param>
        /// <param name="numberOfPagesInSequence">Define the number of pages in a sequence (letter, statement, etc).</param>
        /// <param name="intervalToInsert">Define the interval for inserting a blank page.</param>
        /// <param name="outputPdfPath">Define the output PDF location. Currently not supporting Network Paths.</param>
        void InsertPages(string originalPdfPath, int numberOfPagesInSequence, int intervalToInsert, string outputPdfPath);
    }
}