﻿using NUnit.Framework;
using SwfLib.Data;
using SwfLib.SwfMill.TagFormatting.ControlTags;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.Tests.TagFormatting.ControlTags {
    [TestFixture]
    public class SetBackgroundColorTagFormatterTest : BaseTagFormattingTest<SetBackgroundColorTag, SetBackgroundColorTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = new SetBackgroundColorTag { Color = new SwfRGB(10, 224, 224) };
            ConvertToXmlAndCompare(tag, "SetBackgroundColor.xml");
        }

        [Test]
        public void DoubleConversionTest() {
            DoubleConversionFromResourceTest("SetBackgroundColor.xml");
        }
    }
}
