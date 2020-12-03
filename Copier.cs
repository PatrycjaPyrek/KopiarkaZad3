using System;
using System.Collections.Generic;
using System.Text;
using Podstawowe3;


namespace Zadanie3
{
    public class Copier : BaseDevice
    {
       
        private int counter = 0;

        //liczba wydrukowanych dokumentow
        public int PrintCounter => printer.PrintCounter;
        //liczba zeskanowanych dokumentow
        public int ScanCounter => scanner.ScanCounter;
        public int Counter => counter;
        
        
        Printer printer = new Printer();
        Scanner scanner = new Scanner();
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
     
    }
}
