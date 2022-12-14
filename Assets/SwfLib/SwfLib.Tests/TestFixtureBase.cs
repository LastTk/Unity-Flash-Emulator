﻿using System;
using System.IO;
using NUnit.Framework;
using SwfLib.Tags;

namespace SwfLib.Tests {
    public class TestFixtureBase {

        protected void WriteBits(Stream stream, params string[] bits) {
            var writer = new SwfStreamWriter(stream);
            foreach (var bitString in bits) {
                foreach (var ch in bitString) {
                    switch (ch) {
                        case '0':
                            writer.WriteBit(false);
                            break;
                        case '1':
                            writer.WriteBit(true);
                            break;
                        case '.':
                            break;
                        default:
                            throw new InvalidOperationException("Invalid character " + ch);
                    }
                }
            }
            writer.FlushBits();
            stream.Seek(0, SeekOrigin.Begin);
        }

        protected void CheckBits(Stream stream, params string[] bits) {
            stream.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(stream);
            uint bitIndex = 0;
            foreach (var bitString in bits) {
                foreach (var ch in bitString) {
                    switch (ch) {
                        case '0':
                            Assert.AreEqual(false, reader.ReadBit(), "Checking bit " + bitIndex);
                            bitIndex++;
                            break;
                        case '1':
                            Assert.AreEqual(true, reader.ReadBit(), "Checking bit " + bitIndex);
                            bitIndex++;
                            break;
                        case '.':
                            break;
                        default:
                            throw new InvalidOperationException("Invalid character " + ch);
                    }
                }
            }
            Assert.AreEqual(stream.Length, stream.Position, "Should reach end of the stream");
        }

        protected string GetBits(byte bt) {
            var res = new[] { '0', '0', '0', '0', '0', '0', '0', '0' };
            if ((bt & 0x80) > 0) res[0] = '1';
            if ((bt & 0x40) > 0) res[0] = '1';
            if ((bt & 0x20) > 0) res[0] = '1';
            if ((bt & 0x10) > 0) res[0] = '1';
            if ((bt & 0x08) > 0) res[0] = '1';
            if ((bt & 0x04) > 0) res[0] = '1';
            if ((bt & 0x02) > 0) res[0] = '1';
            if ((bt & 0x01) > 0) res[0] = '1';
            return new string(res);
        }

        protected SwfFile ReadSwfFile(string resourceName) {
            using (var stream = OpenEmbeddedResource(resourceName)) {
                return SwfFile.ReadFrom(stream);
            }
        }

        protected Stream OpenEmbeddedResource(string resourceName) {
            var fullPath = "SwfLib.Tests.Resources.";
            if (!string.IsNullOrEmpty(EmbeddedResourceFolder)) fullPath += EmbeddedResourceFolder + ".";
            fullPath += resourceName;
            var stream = GetType().Assembly.GetManifestResourceStream(fullPath);
            if (stream == null)
                throw new InvalidOperationException("Embedded resource " + resourceName + " is not found");
            return stream;
        }

        protected byte[] GetEmbeddedResourceData(string resourceName) {
            using (var stream = OpenEmbeddedResource(resourceName)) {
                var data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }

        protected SwfTagData ReadEmbeddedTagData(string resourceName, SwfTagType type) {
            var resourcePath = GetType().Namespace + "." + resourceName;
            var stream = GetType().Assembly.GetManifestResourceStream(resourcePath);
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            return new SwfTagData { Data = data, Type = type };
        }

        protected virtual string EmbeddedResourceFolder { get { return ""; } }
    }
}