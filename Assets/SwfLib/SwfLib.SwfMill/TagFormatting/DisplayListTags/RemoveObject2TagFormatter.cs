﻿using System.Xml.Linq;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class RemoveObject2TagFormatter : TagFormatterBase<RemoveObject2Tag> {

        private const string DEPTH_ATTRIB = "depth";

        protected override bool AcceptTagAttribute(RemoveObject2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case DEPTH_ATTRIB:
                    tag.Depth = ushort.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(RemoveObject2Tag tag, XElement xTag) {
            xTag.Add(new XAttribute(DEPTH_ATTRIB, tag.Depth));
        }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        public override string TagName {
            get { return "RemoveObject2"; }
        }
    }
}