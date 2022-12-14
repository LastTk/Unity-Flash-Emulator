﻿namespace SwfLib.Avm2.Opcodes.Branching {
    public class StrictEqualsOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public override string ToString() {
            return "strictequals";
        }
    }
}
