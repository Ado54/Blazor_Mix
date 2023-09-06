using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Project_with_Login.Data;
using Project_with_Login.Helpers;
using SQLitePCL;
using Project_with_Login.Pages;
using Project_with_Login.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Project_with_Login.PDF
{
 
    public class Page1
    { 

        private readonly static string _lopsem = "Blazor is a web framework that allows developers to create interactive web applications using C# and HTML1. A PDF viewer is a component that enables users to open, view, and interact with PDF files in the browser. There are different ways to implement a PDF viewer for Blazor, depending on your needs and preferences.\n\nOne option is to use the Telerik UI for Blazor library, which provides a ready-made PDF viewer";
        private readonly static string _firstName = "Ado" ;

        public static void PageText(Document pdf)
        {
            var title = new Paragraph("Text and Paragraphe", new Font(Font.HELVETICA, 20, Font.BOLD));
            title.SpacingAfter = 18f;

            pdf.Add(title);

            Font _fontStyle = FontFactory.GetFont("Calibri", 8f, Font.ITALIC);

            var phrase = new Phrase(_lopsem, _fontStyle);
            pdf.Add(phrase);

            // Create and add a Paragraph
            var p = new Paragraph(_firstName, _fontStyle);
            p.SpacingBefore = 20f;
            p.SetAlignment("RIGHT");

            pdf.Add(p);


            float margeborder = 1.5f;
            float widhtColumn = 8.5f;
            float space = 1.0f;

            MultiColumnText columns = new MultiColumnText();
            columns.AddSimpleColumn(margeborder.ToDpi(),
                                    pdf.PageSize.Width - margeborder.ToDpi() - space.ToDpi() - widhtColumn.ToDpi());
          columns.AddSimpleColumn(margeborder.ToDpi() + widhtColumn.ToDpi() + space.ToDpi(),
                                   pdf.PageSize.Width - margeborder.ToDpi());

            Paragraph para = new Paragraph(_lopsem, new Font(Font.HELVETICA, 8f));
            para.SpacingAfter = 9f;
            para.Alignment = Element.ALIGN_JUSTIFIED;

            columns.AddElement(para);

          
           pdf.Add(columns);
        }
    }
}