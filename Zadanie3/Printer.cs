using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class Printer : IPrinter
    {
        private int counter;
        public int Counter => counter;
        private int printCounter;
        public int PrintCounter => printCounter;

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
            if (state == IDevice.State.off)
            {
                counter++;
                state = IDevice.State.on;
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
    }
}
