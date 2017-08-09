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


            var pdfTemplate = templateBuilder.GetTemplate();


            // Create a new PDF document
            var document = GetPdfDocument();
           
            var page = AddNewPage(document);

            var graphics = GetGraphicsObject(page);

            var outRectangle = GetOuterRectangle(page);




            var pen = GetBlackPen();

            graphics.DrawRectangle(pen, outRectangle);
        

       /*     gfx.DrawRoundedRectangle(XBrushes.Orange, 130, 0, 100, 60, 30, 20);

            gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 10, 80, 100, 60, 30, 20);

            gfx.DrawRoundedRectangle(pen, XBrushes.Orange, 150, 80, 60, 60, 20, 20);   */


            // Save the document...
            document.Save(filename);
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
