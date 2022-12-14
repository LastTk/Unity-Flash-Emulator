﻿using System.Xml.Linq;
using SwfLib.SwfMill.Actions;
using SwfLib.Tags.ActionsTags;

namespace SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoActionTagFormatter : TagFormatterBase<DoActionTag> {
        private const string ACTIONS_ELEM = "actions";

        protected override bool AcceptTagElement(DoActionTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case ACTIONS_ELEM:
                    foreach (var xAction in element.Elements()) {
                        var action = XAction.FromXml(xAction);
                        tag.ActionRecords.Add(action);
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(DoActionTag tag, XElement xTag) {
            var actions = new XElement(ACTIONS_ELEM);
            foreach (var action in tag.ActionRecords) {
                actions.Add(XAction.ToXml(action));
            }
            xTag.Add(actions);
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DoAction"; }
        }
    }
}
