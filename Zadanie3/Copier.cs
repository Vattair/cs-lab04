using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Copier : IDevice
    {
        private int counter;
        public int Counter => counter;

        private IDevice.State state = IDevice.State.off;

        private Printer printer = new Printer();
        public int PrintCounter => printer.PrintCounter;
        private Scanner scanner = new Scanner();
        public int ScanCounter => scanner.ScanCounter;

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
            if (state == IDevice.State.off)
            {
                counter++;
                state = IDevice.State.on;
            }
        }

        public void Print(in IDocument document)
        {
            if(state == IDevice.State.on)
            {
                printer.PowerOn();
                printer.Print(document);
                printer.PowerOff();
            }
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            document = null;
            if (state == IDevice.State.on)
            {
                scanner.PowerOn();
                scanner.Scan(out document, formatType);
                scanner.PowerOff();
            }
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
