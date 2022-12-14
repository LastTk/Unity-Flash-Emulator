﻿using System.Xml.Linq;
using NUnit.Framework;
using SwfLib.Data;
using SwfLib.Filters;
using SwfLib.SwfMill.Filters;
using SwfLib.Tests.Asserts;

namespace SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XGlowFilterTest {
        private const string ETALON = @"<Glow blurX='1.5' blurY='-2.4' strength='20.5' innerGlow='1' knockout='1' passes='2' compositeSource='1'>
    <color>
        <Color red='137' green='24' blue='87' alpha='20' />
    </color>
</Glow>
";

        [Test]
        public void FromXmlTest() {
            var filter = XGlowFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "Glow");
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XGlowFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private GlowFilter GetSample() {
            return new GlowFilter {
                BlurX = 1.5,
                BlurY = -2.4,
                Color = new SwfRGBA {
                    Red = 137,
                    Green = 24,
                    Blue = 87,
                    Alpha = 20
                },
                Strength = 20.5,
                CompositeSource = true,
                InnerGlow = true,
                Knockout = true,
                Passes = 2
            };
        }
    }
}
