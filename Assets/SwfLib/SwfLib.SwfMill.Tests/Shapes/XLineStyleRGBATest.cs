﻿using System.Xml.Linq;
using NUnit.Framework;
using SwfLib.Data;
using SwfLib.Shapes.LineStyles;
using SwfLib.SwfMill.Shapes;
using SwfLib.Tests.Asserts.Shapes;

namespace SwfLib.SwfMill.Tests.Shapes {
    [TestFixture]
    public class XLineStyleRGBATest {

        private const string ETALON = @"<LineStyle width='2'>
    <color>
        <Color red='143' green='96' blue='224' alpha='128' />
    </color>
</LineStyle>";

        [Test]
        public void FormatTest() {
            var lineStyle = GetLineStyle();
            var xLineStyle = XLineStyleRGBA.ToXml(lineStyle);
            new XmlComparision(Assert.Fail).Compare(XElement.Parse(ETALON), xLineStyle);
        }

        [Test]
        public void ParseTest() {
            var lineStyle = XLineStyleRGBA.FromXml(XElement.Parse(ETALON));
            AssertShape.AreEqual(GetLineStyle(), lineStyle, "lineStyle");
        }

        private static LineStyleRGBA GetLineStyle() {
            return new LineStyleRGBA { Width = 2, Color = new SwfRGBA { Red = 143, Green = 96, Blue = 224, Alpha = 128} };
        }
    }
}
