﻿using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class StoreRegisterXActionTest : BaseXActionTest {
        private const string _etalon = @"<StoreRegister reg='21' />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionStoreRegister>(_etalon);
            Assert.AreEqual(0x15, action.RegisterNumber);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionStoreRegister { RegisterNumber = 0x15 }, _etalon);
        }
    }
}
