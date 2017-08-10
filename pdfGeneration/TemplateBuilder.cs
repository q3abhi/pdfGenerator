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
			return document;

        }


		private IList<XRect> GetAllRectangleObjects(PdfPage page)
        {

			var outerRectangle = GetOuterRectangle (page);


            return new List<XRect>();

        }

		public XRect GetOuterRectangle(PdfPage page)
		{
			var outerRectangle = new XRect(30, 100, page.Width-60, page.Height-150);
			return outerRectangle;
		}
    }
}
