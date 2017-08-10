using NUnit.Framework;
using System;
using pdfGeneration;
namespace pdfTests
{
	[TestFixture]
	public class PdfBuilderTest
	{
		[Test]
		public void ShouldBuildPdfDocument()
		{
			var document = PdfHelper.GetPdfDocument();
			var templateBuilder = new TemplateBuilder (document);
			var builder = new PdfBuilder (templateBuilder);

			builder.BuildPdfDocument ("TestFile.pdf");
		}
	}
}

;