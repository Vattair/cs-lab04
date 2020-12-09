using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
using Zadanie2;
using System;
using System.IO;

namespace UnitTestsZadanie2
{
    [TestClass]
    public class UnitTextZadanie2
    {
        public class ConsoleRedirectionToStringWriter : IDisposable
        {
            private StringWriter stringWriter;
            private TextWriter originalOutput;

            public ConsoleRedirectionToStringWriter()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOutput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }

        [TestMethod]
        public void MD_GetState_StateOff()
        {
            var d = new MultifunctionalDevice();
            d.PowerOff();

            Assert.AreEqual(IDevice.State.off, d.GetState());
        }

        [TestMethod]
        public void MD_GetState_StateOn()
        {
            var d = new MultifunctionalDevice();
            d.PowerOn();

            Assert.AreEqual(IDevice.State.on, d.GetState());
        }

        [TestMethod]
        public void MD_Fax()
        {
            MultifunctionalDevice d = new MultifunctionalDevice();
            d.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("document");
                d.Fax(in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MD_FaxCounter()
        {
            var d = new MultifunctionalDevice();
            d.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            d.Fax(in doc1);
            IDocument doc2 = new TextDocument("aaa.txt");
            d.Fax(in doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            d.Fax(in doc3);

            d.PowerOff();
            d.Fax(in doc3);
            d.PowerOn();

            d.Fax(in doc1);
            d.Fax(in doc2);

            // 5 faksów, gdy urz¹dzenie w³¹czone
            Assert.AreEqual(5, d.FaxCounter);
        }
    }
}