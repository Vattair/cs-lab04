using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        private int printCounter;
        public int PrintCounter => printCounter;
        private int scanCounter;
        public int ScanCounter => scanCounter;
        private int counter;
        public int Counter => counter;

        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                counter++;
                base.PowerOn();
            }
        }
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                printCounter++;
                Console.WriteLine($"{DateTime.Now}, Print: {document.GetFileName()}");
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            if (state == IDevice.State.on) scanCounter++;

            if (formatType == IDocument.FormatType.TXT)
            {
                document = new TextDocument($"TXTScan{ScanCounter}.txt");
            }
            else if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new ImageDocument($"IMAGEScan{ScanCounter}.jpg");
            }
            else
            {
                throw new FormatException();
            }

            if (state == IDevice.State.on) Console.WriteLine($"{DateTime.Now} Scan: {document.GetFileName()}");
        }
        public void ScanAndPrint()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(document);
            }
        }
    }
}
