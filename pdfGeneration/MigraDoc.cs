using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace pdfGeneration
{
    public class MigraDoc
    {
        public void BuildADocument()
        {
            var document = new Document();
            Section section = document.AddSection();
            section.AddParagraph("Hello, World!");
            section.AddParagraph();
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Color = Color.FromCmyk(100, 30, 20, 50);
            paragraph.AddFormattedText("Hello, World!", TextFormat.Underline);
        }
    }
}
