﻿using System.Xml.Linq;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.SwfMill.TagFormatting.DisplayListTags {
    //TODO: format & parse
    public class RemoveObjectTagFormatter : TagFormatterBase<RemoveObjectTag> {
        protected override void FormatTagElement(RemoveObjectTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "RemoveObject"; }
        }
    }
}
