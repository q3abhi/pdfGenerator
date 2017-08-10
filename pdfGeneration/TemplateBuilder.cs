using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace pdfGeneration
{
    public class TemplateBuilder
    {
        private PdfDocument document;

        public TemplateBuilder(PdfDocument documentObject)
        {
            document = documentObject;
        }

        public PdfDocument GetTemplate()
        {
            var page = PdfHelper.AddNewPage(document);
            var graphicsObject = PdfHelper.GetGraphicsObject(page);
            var pen = PdfHelper.GetBlackPen();

            DrawAllRectangles(page, graphicsObject, pen);

			return document;

        }

        private void DrawAllRectangles(PdfPage page,XGraphics graphics, XPen pen)
        {
            var rectanglesToDraw = GetAllRectangleObjects(page);

            foreach (var rectangle in rectanglesToDraw)
            {
                graphics.DrawRectangle(pen,rectangle);
            }

        }


		private IList<XRect> GetAllRectangleObjects(PdfPage page)
        {
            var rectangles = new List<XRect>();

			var outerRectangle = GetOuterRectangle (page);
		    var delDepotRectangle = GetDeliveryDepotRectangle(page, outerRectangle);

            rectangles.Add(outerRectangle);
            rectangles.Add(delDepotRectangle);

		    return rectangles;


        }

		public XRect GetOuterRectangle(PdfPage page)
		{
			var outerRectangle = new XRect(30, 100, page.Width-60, page.Height-150);
			return outerRectangle;
		}

        public XRect GetDeliveryDepotRectangle(PdfPage page, XRect outerRect)
        {
            var rect = new XRect(outerRect.X, outerRect.Y, outerRect.Width - 400, outerRect.Height - 600);
            return rect;
        }
    }
}
