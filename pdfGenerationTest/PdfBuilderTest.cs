using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pdfGeneration;

namespace pdfGenerationTest
{
    [TestClass]
    public class PdfBuilderTest
    {
        [TestMethod]
        public void ShouldBuildPdfDocument()
        {
            var builder = new PdfBuilder();

            builder.BuildPdfDocument("TestFile.pdf");
        }
    }
}
