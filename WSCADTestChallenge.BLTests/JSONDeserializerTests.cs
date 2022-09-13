using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSCADTestChallenge.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using WSCADTestChallenge.BLTests;

namespace WSCADTestChallenge.BL.Tests
{
    [TestClass()]
    public class JSONDeserializerTests
    {
        [TestMethod()]
        public void TestJsonArrayConverter()
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new ShapeListConverterWithTypeDiscriminator());

            var result = JsonSerializer.Deserialize<List<Shape>>(MockJsonData.jsonArray, serializeOptions);

            var expected1 = new Line()
            { a = "-1,5; 3,4", b = "2,2; 5,7", color = "127; 255; 255; 255", filled = false, type = null };

            var expected2 = new Circle()
            { center = "0; 0", radius = 15.0, color = "127; 255; 0; 0", filled = false, type = null };

            var expected3 = new Triangle()
            { a = "-15; -20", b = "15; -20,3", c = "0; 21", color = "127; 255; 0; 255", filled = true, type = null };

            Assert.AreEqual(result.Count(), 3);

            Assert.AreEqual(((Line)result[0]).a, expected1.a);
            Assert.AreEqual(((Line)result[0]).b, expected1.b);
            Assert.AreEqual(((Line)result[0]).color, expected1.color);
            Assert.AreEqual(((Line)result[0]).filled, expected1.filled);

            Assert.AreEqual(((Circle)result[1]).center, expected2.center);
            Assert.AreEqual(((Circle)result[1]).radius, expected2.radius);
            Assert.AreEqual(((Circle)result[1]).color, expected2.color);
            Assert.AreEqual(((Circle)result[1]).filled, expected2.filled);

            Assert.AreEqual(((Triangle)result[2]).a, expected3.a);
            Assert.AreEqual(((Triangle)result[2]).b, expected3.b);
            Assert.AreEqual(((Triangle)result[2]).c, expected3.c);
            Assert.AreEqual(((Triangle)result[2]).color, expected3.color);
            Assert.AreEqual(((Triangle)result[2]).filled, expected3.filled);
        }
    }
}
