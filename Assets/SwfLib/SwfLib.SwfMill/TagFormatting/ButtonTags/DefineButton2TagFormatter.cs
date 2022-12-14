﻿using System.Xml.Linq;
using SwfLib.SwfMill.Buttons;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.ButtonTags;

namespace SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButton2TagFormatter : DefineButtonBaseTagFormatter<DefineButton2Tag> {

        private const string MENU_ATTRIB = "menu";
        private const string BUTTONS_SIZE_ATTRIB = "buttonsSize";
        private const string BUTTONS_ELEM = "buttons";
        private const string CONDITIONS_ELEM = "conditions";

        protected override bool AcceptTagAttribute(DefineButton2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case MENU_ATTRIB:
                    tag.TrackAsMenu = CommonFormatter.ParseBool(attrib.Value);
                    break;
                case BUTTONS_SIZE_ATTRIB:
                    break;
                case "reserved":
                    tag.ReservedFlags = byte.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DefineButton2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BUTTONS_ELEM:
                    foreach (var xButton in element.Elements()) {
                        tag.Characters.Add(XButtonRecordEx.FromXml(xButton));
                    }
                    break;
                case CONDITIONS_ELEM:
                    foreach (var xCondition in element.Elements()) {
                        tag.Conditions.Add(XButtonCondition.FromXml(xCondition));
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(DefineButton2Tag tag, XElement xTag) {
            xTag.Add(new XAttribute(MENU_ATTRIB, CommonFormatter.Format(tag.TrackAsMenu)));
            if (tag.ReservedFlags != 0) {
                xTag.Add(new XAttribute("reserved", tag.ReservedFlags));
            }

            var xButtons = new XElement("buttons");
            foreach (var button in tag.Characters) {
                xButtons.Add(XButtonRecordEx.ToXml(button));
            }
            xTag.Add(xButtons);

            var xConditions = new XElement("conditions");
            foreach (var condition in tag.Conditions) {
                xConditions.Add(XButtonCondition.ToXml(condition));
            }
            xTag.Add(xConditions);
        }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        public override string TagName {
            get { return "DefineButton2"; }
        }

        protected override ushort? GetObjectID(DefineButton2Tag tag) {
            return tag.ButtonID;
        }

        protected override void SetObjectID(DefineButton2Tag tag, ushort value) {
            tag.ButtonID = value;
        }

    }
}
