﻿using System.Xml.Linq;
using SwfLib.Fonts;
using SwfLib.SwfMill.Data;

namespace SwfLib.SwfMill.Fonts {
    public static class XZoneData {

        public static ZoneData FromXml(XElement xZoneData) {
            var xPosition = xZoneData.Attribute("position");
            var xSize = xZoneData.Attribute("size");
            return new ZoneData {
                Position = CommonFormatter.ParseDouble(xPosition.Value),
                Size = CommonFormatter.ParseDouble(xSize.Value)
            };
        }

        public static XElement ToXml(ZoneData data) {
            return new XElement("ZoneData",
                new XAttribute("position", CommonFormatter.Format(data.Position)),
                new XAttribute("size", CommonFormatter.Format(data.Size))
            );
        }
    }
}
