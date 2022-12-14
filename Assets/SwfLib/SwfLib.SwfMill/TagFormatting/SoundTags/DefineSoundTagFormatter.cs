﻿using System.Xml.Linq;
using SwfLib.Tags.SoundTags;

namespace SwfLib.SwfMill.TagFormatting.SoundTags {
    public class DefineSoundTagFormatter : TagFormatterBase<DefineSoundTag> {
        protected override void FormatTagElement(DefineSoundTag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineSound"; }
        }
    }
}
