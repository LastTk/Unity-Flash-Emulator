﻿using System.Xml.Linq;
using SwfLib.Shapes.LineStyles;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Shapes {
    public class XLineStyleRGBA {

        public static XElement ToXml(LineStyleRGBA lineStyle) {
            return new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XElement("color", XColorRGBA.ToXml(lineStyle.Color)));
        }

        public static LineStyleRGBA FromXml(XElement xLineStyle) {
            var xColor = xLineStyle.RequiredElement("color").Element("Color");
            return new LineStyleRGBA {
                Width = xLineStyle.RequiredUShortAttribute("width"),
                Color = XColorRGBA.FromXml(xColor)
            };
        }
    }
}
