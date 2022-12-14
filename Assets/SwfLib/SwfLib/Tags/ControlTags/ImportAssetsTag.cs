﻿namespace SwfLib.Tags.ControlTags {
    public class ImportAssetsTag : ControlBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.ImportAssets; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
