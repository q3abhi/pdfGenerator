using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenHtmlToPdf;
using PdfSharp;


namespace SampleMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BuildPdfDocument("testpdf.pdf");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {

                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

        public void BuildPdfDocument(string filename)
        {

            //    var pdfDocumentTemplate = _templateBuilder.GetTemplate();

            var htmlText = RenderRazorViewToString("Index", new object());


            var pdf = Pdf
                .From(htmlText)
                .OfSize(PaperSize.A4)
                .WithTitle("Title")
                .WithoutOutline()
                .WithMargins(1.25.Centimeters())
                .Portrait()
                .Comressed()
                .Content();

            System.IO.File.WriteAllBytes("D:/" + filename, pdf);

           /* var pdfDocumentTemplate =
                TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(htmlText, PageSize.A4);

            pdfDocumentTemplate.Save("D:/" + filename);*/
        }
    }
}