using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oml.NET.Base;
using Oml.NET.IO;

namespace Oml.NET.Tests
{
    [TestClass]
    public class SerializingTests
    {
        [TestMethod]
        public void BasicSerializingTest()
        {
            IOmlDocument doc = new OmlDocument {
                new OmlHeader(),
                new OmlComment("Hello, world!"),
                new OmlProperty("FirstValue", 1),
                new OmlProperty("TestProperty", new string[] { "foo", "bar", "baz" }),
                new OmlSection("Section"),
                new OmlProperty("IAmUnderASection", true),
                new OmlProperty("IAmAlsoUnderASection", "wow")
            };

            
        }
    }
}
