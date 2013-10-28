using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MiaoBlog.Infrastructure.Helpers;

namespace MiaoBlog.Infrastructure.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileStream fs = new FileStream("samplehtml.txt", FileMode.Open, FileAccess.Read);
            int length = int.Parse(fs.Length.ToString());
            byte[] result = new byte[length];
            fs.Read(result, 0, length - 1);
            string str = System.Text.Encoding.Default.GetString(result);
            string resultString = Translators.ExcerptTranslator(str, 100);
            Console.Write(result.ToString());
        }
    }
}
