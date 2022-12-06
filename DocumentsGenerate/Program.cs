// See https://aka.ms/new-console-template for more information


using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

Console.WriteLine("Hello, World!");

CreatePdf();

void CreatePdf()
{
    PdfWriter writer = new PdfWriter("sample.pdf");
    PdfDocument pdfDocument = new PdfDocument(writer);
    Document document = new Document(pdfDocument);



    #region Image
    Image img = new Image(ImageDataFactory
            .Create("logo.png"))
            .SetWidth(100)
            .SetTextAlignment(TextAlignment.LEFT)
            .SetHorizontalAlignment(HorizontalAlignment.LEFT);
    document.Add(img);
    #endregion
    #region Header
    Paragraph header = new Paragraph("Informe mensual")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(20)
            .SetBold();

    document.Add(header);
    #endregion
    #region Subheader
    Paragraph subheader = new Paragraph(DateTime.Now.ToString())
        .SetTextAlignment(TextAlignment.CENTER)
        .SetFontSize(12);
    document.Add(subheader);
    #endregion

    LineSeparator ls = new LineSeparator(new SolidLine());
    document.Add(ls);

    Table table = new Table(3, true);
    Cell cell11 = new Cell(1, 1)
       .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
       .SetTextAlignment(TextAlignment.CENTER)
       .Add(new Paragraph("No"));

    Cell cell12 = new Cell(1, 1)
       .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
       .SetTextAlignment(TextAlignment.CENTER)
       .Add(new Paragraph("Nombre"));

    Cell cell13 = new Cell(1, 1)
       .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
       .SetTextAlignment(TextAlignment.CENTER)
       .Add(new Paragraph("Diferencia de peso"));

    table.AddCell(cell11);
    table.AddCell(cell12);
    table.AddCell(cell13);

    string[] Names = new[] { "Frijol", "Calabaza", "Bonia"};
    var Weigths = new List<float>() { 0.10f, 0.15f, 0.20f, 0.25f, 0.30f, 0.35f, 0.40f, 0.45f, 0.50f };
    for (int i = 0; i < 50; i++)
    {
        Cell no = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph((i + 1).ToString()));
        Cell name = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph(Names[i % 3]));
        Cell diff = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph(Weigths[i % 9].ToString()));

        table.AddCell(no)
            .AddCell(name)
            .AddCell(diff);
    }

    document.Add(table);

    /*int n = pdfDocument.GetNumberOfPages();
    for (int i = 1; i <= n; i++)
    {
        document.ShowTextAligned(new Paragraph(String
           .Format("Page" + i + " of " + n)),
           600, 806, i, TextAlignment.RIGHT,
           VerticalAlignment.TOP, 0);
    }*/

    document.Close();
}