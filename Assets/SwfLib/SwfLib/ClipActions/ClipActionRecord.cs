﻿using System.Collections.Generic;
using SwfLib.Actions;

namespace SwfLib.ClipActions {
    public class ClipActionRecord {

        public ClipEventFlags Flags;

        public byte KeyCode;

        public readonly IList<ActionBase> Actions = new List<ActionBase>();

    }
}
