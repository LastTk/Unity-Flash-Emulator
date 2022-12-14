﻿using System.Xml.Linq;
using SwfLib.SwfMill.Shapes;
using SwfLib.Tags.ShapeTags;

namespace SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape3TagFormatter : DefineShapeBaseFormatter<DefineShape3Tag> {

        protected override XElement FormatStyles(DefineShape3Tag tag) {
            return XStyleList.ToXml(tag.FillStyles, tag.LineStyles);
        }

        protected override XElement FormatShape(DefineShape3Tag tag) {
            return XShape.ToXml(tag.ShapeRecords);
        }

        protected override void ReadShapes(DefineShape3Tag tag, XElement xShape) {
            XShape.FromXml(xShape, tag.ShapeRecords);
        }

        protected override void ReadStyles(DefineShape3Tag tag, XElement xStyleList) {
            XStyleList.FromXml(xStyleList, tag.FillStyles, tag.LineStyles);
        }

        public override string TagName {
            get { return "DefineShape3"; }
        }

    }
}