﻿using System.Linq;
using System.Xml.Linq;
using SwfLib.Tags;

namespace SwfLib.SwfMill.TagFormatting {
    /// <summary>
    /// Represents DefineSpriteTag xml formatter.
    /// </summary>
    public class DefineSpriteTagFormatter : TagFormatterBase<DefineSpriteTag> {
        private readonly ushort _version;
        private readonly TagFormatterFactory _subFormatterFactory;

        private const string FRAMES_ATTRIB = "frames";
        private const string TAGS_ELEMENTS = "tags";

        public DefineSpriteTagFormatter(ushort version) {
            _version = version;
            _subFormatterFactory = new TagFormatterFactory(version);
        }

        protected override bool AcceptTagAttribute(DefineSpriteTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case FRAMES_ATTRIB:
                    tag.FramesCount = ushort.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DefineSpriteTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case TAGS_ELEMENTS:
                    ReadTags(tag, element);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(DefineSpriteTag tag, XElement xTag) {
            xTag.Add(new XAttribute("frames", tag.FramesCount));
            xTag.Add(new XElement("tags", tag.Tags.Select(BuildTagXml)));
        }

        private static void ReadTags(DefineSpriteTag tag, XElement tagsElement) {
            //TODO: Transfer version here
            var formatterFactory = new TagFormatterFactory(10);
            foreach (var tagElem in tagsElement.Elements()) {
                var subTag = SwfTagNameMapping.CreateTagByXmlName(tagElem.Name.LocalName);
                var formatter = formatterFactory.GetFormatter(subTag);
                subTag = formatter.ParseTo(tagElem, subTag);
                tag.Tags.Add(subTag);
            }

        }

        protected XElement BuildTagXml(SwfTagBase tag) {
            var subFormatter = _subFormatterFactory.GetFormatter(tag);
            return subFormatter.FormatTag(tag);
        }

        public override string TagName {
            get { return "DefineSprite"; }
        }

        protected override ushort? GetObjectID(DefineSpriteTag tag) {
            return tag.SpriteID;
        }

        protected override void SetObjectID(DefineSpriteTag tag, ushort value) {
            tag.SpriteID = value;
        }
    }
}
