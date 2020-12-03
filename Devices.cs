using System;

namespace Podstawowe3
{
    public interface IDevice
    {
        enum State { on, off };

        void PowerOn(); // uruchamia urządzenie, zmienia stan na `on`
        void PowerOff(); // wyłącza urządzenie, zmienia stan na `off
        State GetState(); // zwraca aktualny stan urządzenia

        int Counter { get; }  // zwraca liczbę charakteryzującą eksploatację urządzenia,
                              // np. liczbę uruchomień, liczbę wydrukow, liczbę skanów, ...
    }

    public abstract class BaseDevice : IDevice
    {
        protected IDevice.State state = IDevice.State.off;
        public IDevice.State GetState() => state;

        public void PowerOff()
        {
            state = IDevice.State.off;
            Console.WriteLine("... Device is off !");
        }

        public void PowerOn()
        {
            state = IDevice.State.on;
            Console.WriteLine("Device is on ...");
        }

        public int Counter { get; private set; } = 0;
    }

    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od `null`</param>
        void Print(in IDocument document);
    }

    public interface IScanner : IDevice
    {
        // dokument jest skanowany, jeśli urządzenie włączone
        // w przeciwnym przypadku nic się dzieje
        void Scan(out IDocument document, IDocument.FormatType formatType);
    }
    public interface IFax : IDevice, IScanner, IPrinter
    {
        void Fax(IDocument document, object Nadawca, object Odbiorca)
        {

            Scan(out document, IDocument.FormatType.PDF);
            Print(in document);
            Wyslij(Nadawca, Odbiorca);

        }

        void Wyslij(object nadawca, object odbiorca);
    }
    public class Printer : BaseDevice, IPrinter
    {
        public int PrintCounter => printCounter;
        private int printCounter = 0;


        public void Print(in IDocument document)
        {

            Console.WriteLine(DateTime.Now + "Print: " + document.GetFileName());

            printCounter += 1;
        }
    }
    public class Scanner : BaseDevice, IScanner
    {
        private int scanCounter = 0;
        public int ScanCounter => scanCounter;


        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            switch (formatType)
            {
                case IDocument.FormatType.JPG:
                    document = new ImageDocument($"ImageScan{ScanCounter}.jpg");

                    break;
                case IDocument.FormatType.PDF:
                    document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                    break;
                default:
                    document = new TextDocument($"TextScan{ScanCounter}.txt");
                    break;

            }
            Console.WriteLine(DateTime.Now + "Scan: " + document.GetFileName());
            scanCounter += 1;
        }
    }
    public class Fax : BaseDevice, IFax
    {
        private int faxCounter = 0;
      
        public int FaxCounter => faxCounter;

        public object ScanCounter { get; private set; }
        
        public void Wyslij(object nadawca, object odbiorca)
        {
            Console.WriteLine($"Nadawca: {nadawca}\nOdbiorca: {odbiorca}");
            faxCounter += 1;
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            switch (formatType)
            {
                case IDocument.FormatType.JPG:
                    document = new ImageDocument($"ImageScan{ScanCounter}.jpg");

                    break;
                case IDocument.FormatType.PDF:
                    document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                    break;
                default:
                    document = new TextDocument($"TextScan{ScanCounter}.txt");
                    break;

            }
            Console.WriteLine(DateTime.Now + "Scan: " + document.GetFileName());
            
        }

        public void Print(in IDocument document)
        {

            Console.WriteLine(DateTime.Now + "Print: " + document.GetFileName());

           
        }
    }
}