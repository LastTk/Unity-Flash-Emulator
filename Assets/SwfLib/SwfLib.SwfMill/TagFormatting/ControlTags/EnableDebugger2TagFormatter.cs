﻿using System.Xml.Linq;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    /// <summary>
    /// Represents EnableDebugger2Tag xml formatter.
    /// </summary>
    public class EnableDebugger2TagFormatter : TagFormatterBase<EnableDebugger2Tag> {

        protected override void FormatTagElement(EnableDebugger2Tag tag, XElement xTag) {
        }

        protected override byte[] GetData(EnableDebugger2Tag tag) {
            return tag.Data;
        }

        protected override void SetData(EnableDebugger2Tag tag, byte[] data) {
            tag.Data = data;
        }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        public override string TagName {
            get { return "EnableDebugger2"; }
        }
    }
}
