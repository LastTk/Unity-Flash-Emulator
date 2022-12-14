﻿using System.Xml.Linq;
using NUnit.Framework;
using SwfLib.Filters;
using SwfLib.Gradients;
using SwfLib.SwfMill.Filters;
using SwfLib.Tests.Asserts;

namespace SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XGradientBevelFilterTest {
        private const string ETALON = @"<GradientBevel blurX='1.5' blurY='-2.4' strength='20.5' angle='3.45' distance='29.7' innerGlow='1' knockout='1' passes='2' compositeSource='1' onTop='1'>
    <gradientColors>
        <GradientItem position='0'>
            <color>
                <Color red='1' green='2' blue='3' alpha='4' />
            </color>
        </GradientItem>
        <GradientItem position='10'>
            <color>
                <Color red='5' green='6' blue='7' alpha='8' />
            </color>
        </GradientItem>
    </gradientColors>
</GradientBevel>
";

        [Test]
        public void FromXmlTest() {
            var filter = XGradientBevelFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "GradientBevel");
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XGradientBevelFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private GradientBevelFilter GetSample() {
            return new GradientBevelFilter {
                BlurX = 1.5,
                BlurY = -2.4,
                GradientColors = {
                    new GradientRecordRGBA { Ratio = 0, Color = {Red = 1, Green = 2, Blue = 3, Alpha = 4}},
                    new GradientRecordRGBA { Ratio = 10, Color = {Red = 5, Green = 6, Blue = 7, Alpha = 8}}
                },
                Strength = 20.5,
                CompositeSource = true,
                InnerGlow = true,
                Knockout = true,
                Passes = 2,
                Angle = 3.45,
                Distance = 29.7,
                OnTop = true
            };
        }
    }
}
