using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Podstawowe3;


namespace Zadanie3
{
    public class MultifunctionalDevice : BaseDevice
    {
        public class Copier : BaseDevice
        {

            private int counter = 0;

            //liczba wydrukowanych dokumentow
            public int PrintCounter => printer.PrintCounter;
            //liczba zeskanowanych dokumentow
            public int ScanCounter => scanner.ScanCounter;
            public int FaxCounter => fax.Counter;
            public int Counter => counter;


            Printer printer = new Printer();
            Scanner scanner = new Scanner();
            Fax fax = new Fax();
            public void Print(in IDocument document)
            {

                printer.PowerOn();

                printer.Print(document);
                printer.PowerOff();
                counter += 1;
            }
            public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
            {

                scanner.PowerOn();

                scanner.Scan(out document, formatType);
                scanner.PowerOff();
                counter += 1;
            }
            public void ScanAndPrint()
            {


                IDocument document;
                Scan(out document, IDocument.FormatType.JPG);
                Print(document);


                counter += 1;

            }
            public void Fax(IDocument document, object nadawca, object odbiorca)
            {
                fax.PowerOn();
                Console.WriteLine("Wyslano faxem: ");
                scanner.Scan(out document, IDocument.FormatType.PDF);
                Wyslij(nadawca, odbiorca);
                Console.Write("Odebrano: ");
                printer.Print(document);

                Console.Write(document.GetFileName());
                counter += 1;
            }
            public void Wyslij(object nadawca, object odbiorca)
            {
                Console.WriteLine($"Nadawca: {nadawca}\nOdbiorca: {odbiorca}");
            }
           
        }

    }
}





