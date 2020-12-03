using Podstawowe3;
using System;
using Zadanie3;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {

            var xerox = new Copier();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);
            xerox.Scan(out doc1);

             xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);
        }
    }
}
