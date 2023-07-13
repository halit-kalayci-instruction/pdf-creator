// See https://aka.ms/new-console-template for more information
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
var byteArray = Document.Create(document =>
{
    document.Page(page =>
    {
        page.DefaultTextStyle(x => x.FontFamily("Times New Roman"));
        page.Margin(1, QuestPDF.Infrastructure.Unit.Inch);
        page.Header().Text("TKI Demirbaşlar");
        page.Footer().Text(text => text.CurrentPageNumber());
    });

}).GeneratePdf();

System.IO.File.WriteAllBytes("hello.pdf", byteArray);

Process proc = new Process();
proc.StartInfo.UseShellExecute = true;
proc.StartInfo.FileName = "hello.pdf";
proc.Start();