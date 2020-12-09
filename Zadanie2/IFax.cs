using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Zadanie1;

namespace Zadanie2
{
    interface IFax : IDevice
    {
        public void Fax(in IDocument document);
    }
}
