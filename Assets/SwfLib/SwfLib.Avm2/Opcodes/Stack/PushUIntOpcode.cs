﻿namespace SwfLib.Avm2.Opcodes.Stack {
    public class PushUIntOpcode : BaseAvm2Opcode {

        public override TResult AcceptVisitor<TArg, TResult>(IAvm2OpcodeVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public uint Value { get; set; }
    }
}
