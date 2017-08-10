using System;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace pdfGeneration
{
    public static class PdfHelper
    {

        public static PdfPage AddNewPage(PdfDocument document)
        {
            var page = document.AddPage();
            return page;
        }

        public static XFont GetFont()
        {
            var font = new XFont("Myriad Pro", 25, XFontStyle.Bold);
            return font;
        }

        public static XRect GetOuterRectangle(PdfPage page)
        {
            var outerRectangle = new XRect(30, 100, page.Width - 60, page.Height - 150);
            return outerRectangle;
        }

        public static XGraphics GetGraphicsObject(PdfPage page)
        {
            var graphics = XGraphics.FromPdfPage(page);
            return graphics;
        }

        public static XPen GetBlackPen()
        {
            var pen = new XPen(XColors.Black, Math.PI);
            return pen;
        }

        public static void SetPageOrientationAndSize(PdfPage page)
        {
            page.Size = PageSize.A4;
            page.Orientation = PageOrientation.Portrait;
        }

		public static PdfDocument GetPdfDocument()
		{
			var document = new PdfDocument();
			return document;
		}
    }
}
