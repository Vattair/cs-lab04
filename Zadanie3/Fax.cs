using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class FaxDevice : IFax
    {
        private int faxCounter;
        public int FaxCounter => faxCounter;

        private int counter;
        public int Counter => counter;

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

        public void Fax(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                faxCounter++;
                Console.WriteLine($"{DateTime.Now} Fax: {document.GetFileName()}");
            }
        }
    }
}
