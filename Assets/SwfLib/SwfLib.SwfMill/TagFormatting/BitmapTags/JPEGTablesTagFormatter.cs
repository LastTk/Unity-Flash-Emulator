﻿using System.Xml.Linq;
using SwfLib.Tags.BitmapTags;

namespace SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class JPEGTablesTagFormatter : TagFormatterBase<JPEGTablesTag> {

        protected override void FormatTagElement(JPEGTablesTag tag, XElement xTag) {
        }

        protected override byte[] GetData(JPEGTablesTag tag) {
            return tag.JPEGData;
        }

        protected override void SetData(JPEGTablesTag tag, byte[] data) {
            tag.JPEGData = data;
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "JPEGTables"; }
        }
    }
}
