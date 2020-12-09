using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class Scanner : IScanner
    {
        private int counter;
        public int Counter => counter;
        private int scanCounter;
        public int ScanCounter => scanCounter;

        private IDevice.State state = IDevice.State.off;

        public IDevice.State GetState()
        {
            return state;
        }

        public void PowerOff()
        {
            state = IDevice.State.off;
        }

        public void PowerOn()
        {
            if(state == IDevice.State.off)
            {
                counter++;
                state = IDevice.State.on;
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
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
    }
}
