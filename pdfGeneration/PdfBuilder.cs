using System;
using System.Diagnostics;
using System.Drawing;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace pdfGeneration
{
    public class PdfBuilder
    {

        private TemplateBuilder templateBuilder;

        public PdfBuilder(TemplateBuilder templateBuilderObject)
        {
            templateBuilder = templateBuilderObject;
        }


        public void BuildPdfDocument(string filename)
        {

            var pdfDocumentTemplate = templateBuilder.GetTemplate();

            pdfDocumentTemplate.Save(filename);
        }

        public PdfPage AddNewPage(PdfDocument document)
        {
            var page = document.AddPage();
            return page;
        }

        public XFont GetFont()
        {
              // Create a font
            var font = new XFont("Myriad Pro", 25, XFontStyle.Bold);
            return font;
        }

        public XRect GetOuterRectangle(PdfPage page)
        {
            var outerRectangle = new XRect(30, 100, page.Width-60, page.Height-150);
            return outerRectangle;
        }

        public XGraphics GetGraphicsObject(PdfPage page)
        {
            var graphics = XGraphics.FromPdfPage(page);
            return graphics;
        }

        public XPen GetBlackPen()
        {
            var pen = new XPen(XColors.Black, Math.PI);
            return pen;
        }

        public void SetPageOrientationAndSize(PdfPage page)
        {
            page.Size = PageSize.A4;
            page.Orientation = PageOrientation.Portrait;
        }

        public PdfDocument GetPdfDocument()
        {
            var document = new PdfDocument();
            return document;
        }

    }
}
