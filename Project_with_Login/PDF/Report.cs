using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;
using Project_with_Login.Helpers;

namespace Project_with_Login.PDF;
public class Report
{

    private int _pagenumber;

    public void Generate(IJSRuntime js, int pagenumber, string filename = "report.pdf")
    {
        _pagenumber = pagenumber;

        js.InvokeVoidAsync("jsDownloadFile",
                            filename,
                            ReportPDF()
                            );
    }

    public void OpenToIframe(IJSRuntime js, int pagenumber, string idiFrame)
    {
        _pagenumber = pagenumber;

        js.InvokeVoidAsync("jsOpenToIframe",
                            idiFrame,
                            Convert.ToBase64String(ReportPDF())
                            );
    }
    public void OpenNewTab(IJSRuntime js, int pagenumber, string filename = "report.pdf")
    {
        _pagenumber = pagenumber;

        js.InvokeVoidAsync("jsOpenIntoNewTab",
                            filename,
                            Convert.ToBase64String(ReportPDF())
                            );
    }


    private byte[] ReportPDF()
    {
        var memoryStream = new MemoryStream();

        // Marge in centimeter, then I convert with .ToDpi()
        float margeLeft = 1.5f;
        float margeRight = 1.5f;
        float margeTop = 1.0f;
        float margeBottom = 1.0f;

        Document pdf = new Document(
                                PageSize.A4,
                                margeLeft.ToDpi(),
                                margeRight.ToDpi(),
                                margeTop.ToDpi(),
                                margeBottom.ToDpi()
                               );

        pdf.AddTitle("Blazor-PDF");
        pdf.AddAuthor("Christophe Peugnet");
        pdf.AddCreationDate();
        pdf.AddKeywords("blazor");
        pdf.AddSubject("Create a pdf file with iText");

        PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

        //HEADER and FOOTER
        var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
        var labelHeader = new Chunk("Header PDF", fontStyle);
        HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
        {
            BackgroundColor = new BaseColor(102, 178, 255),
            Alignment = Element.ALIGN_CENTER,
           Border = iTextSharp.text.Rectangle.NO_BORDER
        };
        //header.Border = Rectangle.NO_BORDER;
        pdf.Header = header;


        var labelFooter = new Chunk("Page", fontStyle);
        HeaderFooter footer = new HeaderFooter(new Phrase(labelFooter), true)
        {
            Border = iTextSharp.text.Rectangle.NO_BORDER,
            Alignment = Element.ALIGN_RIGHT
        };
        pdf.Footer = footer;

        pdf.Open();


        if (_pagenumber == 1)
            Page1.PageText(pdf);

        pdf.Close();

        return memoryStream.ToArray();
    }



}
