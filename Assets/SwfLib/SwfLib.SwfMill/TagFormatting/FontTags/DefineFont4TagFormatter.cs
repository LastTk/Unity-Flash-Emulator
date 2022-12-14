﻿using System.Xml.Linq;
using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    //TODO: format & parse
    public class DefineFont4TagFormatter : DefineFontBaseFormatter<DefineFont4Tag> {
        protected override void FormatTagElement(DefineFont4Tag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineFont4"; }
        }
    }
}
