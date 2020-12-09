using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Zadanie1;

namespace Zadanie2
{
    public class MultifunctionalDevice : Copier, IFax
    {
        private int faxCounter;
        public int FaxCounter => faxCounter;
        public void Fax(in IDocument document)
        {
            if(state == IDevice.State.on)
            {
                faxCounter++;
                Console.WriteLine($"{DateTime.Now} Fax: {document.GetFileName()}");
            }
        }
    }
}
