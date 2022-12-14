﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwfLib.Filters;

namespace SwfLib.Tests.Asserts {
    public static class AssertFilters {

        public static void AreEqual(ConvolutionFilter expected, ConvolutionFilter actual, string message) {
            Assert.AreEqual(expected.Divisor, actual.Divisor);
            Assert.AreEqual(expected.Bias, actual.Bias);

            Assert.AreEqual(expected.MatrixX, actual.MatrixX);
            Assert.AreEqual(expected.MatrixY, actual.MatrixY);
            for (var x = 0; x < actual.MatrixX; x++) {
                for (var y = 0; y < actual.MatrixX; y++) {
                    Assert.AreEqual(expected.Matrix[y, x], actual.Matrix[y, x]);
                }
            }

            AssertColors.AreEqual(expected.DefaultColor, actual.DefaultColor, "DefaultColor");
            Assert.AreEqual(expected.Reserved, actual.Reserved);
            Assert.AreEqual(expected.Clamp, actual.Clamp);
            Assert.AreEqual(expected.PreserveAlpha, actual.PreserveAlpha);
        }

        public static void AreEqual(BlurFilter expected, BlurFilter actual, string message) {
            Assert.AreEqual(expected.BlurX, actual.BlurX, message + ".BlurX");
            Assert.AreEqual(expected.BlurY, actual.BlurY, message + ".BlurY");
            Assert.AreEqual(expected.Passes, actual.Passes);
            Assert.AreEqual(expected.Reserved, actual.Reserved);
        }

        public static void AreEqual(GlowFilter expected, GlowFilter actual, string message) {
            Assert.AreEqual(expected.BlurX, actual.BlurX, message + ".BlurX");
            Assert.AreEqual(expected.BlurY, actual.BlurY, message + ".BlurY");
            AssertColors.AreEqual(expected.Color, actual.Color, "Color");
            Assert.AreEqual(expected.CompositeSource, actual.CompositeSource);
            Assert.AreEqual(expected.InnerGlow, actual.InnerGlow);
            Assert.AreEqual(expected.Knockout, actual.Knockout);
            Assert.AreEqual(expected.Passes, actual.Passes);
            Assert.AreEqual(expected.Strength, actual.Strength);
        }

        public static void AreEqual(GradientGlowFilter expected, GradientGlowFilter actual, string message) {
            Assert.AreEqual(expected.BlurX, actual.BlurX, message + ".BlurX");
            Assert.AreEqual(expected.BlurY, actual.BlurY, message + ".BlurY");
            AssertGradients.AreEqual(expected.GradientColors, actual.GradientColors, "GradientColors");
            Assert.AreEqual(expected.CompositeSource, actual.CompositeSource);
            Assert.AreEqual(expected.InnerGlow, actual.InnerGlow);
            Assert.AreEqual(expected.Knockout, actual.Knockout);
            Assert.AreEqual(expected.Passes, actual.Passes);
            Assert.AreEqual(expected.Strength, actual.Strength);
            Assert.AreEqual(expected.Angle, actual.Angle);
            Assert.AreEqual(expected.Distance, actual.Distance);
            Assert.AreEqual(expected.OnTop, actual.OnTop);
        }

        public static void AreEqual(BevelFilter expected, BevelFilter actual, string message) {
            Assert.AreEqual(expected.BlurX, actual.BlurX, message + ".BlurX");
            Assert.AreEqual(expected.BlurY, actual.BlurY, message + ".BlurY");
            AssertColors.AreEqual(expected.ShadowColor, actual.ShadowColor, "ShadowColor");
            AssertColors.AreEqual(expected.HighlightColor, actual.HighlightColor, "HighlightColor");
            Assert.AreEqual(expected.CompositeSource, actual.CompositeSource);
            Assert.AreEqual(expected.InnerShadow, actual.InnerShadow);
            Assert.AreEqual(expected.Knockout, actual.Knockout);
            Assert.AreEqual(expected.Passes, actual.Passes);
            Assert.AreEqual(expected.Strength, actual.Strength);
            Assert.AreEqual(expected.Angle, actual.Angle);
            Assert.AreEqual(expected.Distance, actual.Distance);
            Assert.AreEqual(expected.OnTop, actual.OnTop);
        }

        public static void AreEqual(GradientBevelFilter expected, GradientBevelFilter actual, string message) {
            Assert.AreEqual(expected.BlurX, actual.BlurX, message + ".BlurX");
            Assert.AreEqual(expected.BlurY, actual.BlurY, message + ".BlurY");
            AssertGradients.AreEqual(expected.GradientColors, actual.GradientColors, "GradientColors");
            Assert.AreEqual(expected.CompositeSource, actual.CompositeSource);
            Assert.AreEqual(expected.InnerGlow, actual.InnerGlow);
            Assert.AreEqual(expected.Knockout, actual.Knockout);
            Assert.AreEqual(expected.Passes, actual.Passes);
            Assert.AreEqual(expected.Strength, actual.Strength);
            Assert.AreEqual(expected.Angle, actual.Angle);
            Assert.AreEqual(expected.Distance, actual.Distance);
            Assert.AreEqual(expected.OnTop, actual.OnTop);
        }

        public static void AreEqual(DropShadowFilter expected, DropShadowFilter actual, string message) {
            Assert.AreEqual(expected.BlurX, actual.BlurX, message + ".BlurX");
            Assert.AreEqual(expected.BlurY, actual.BlurY, message + ".BlurY");
            AssertColors.AreEqual(expected.Color, actual.Color, message + ".Color");
            Assert.AreEqual(expected.CompositeSource, actual.CompositeSource);
            Assert.AreEqual(expected.InnerShadow, actual.InnerShadow);
            Assert.AreEqual(expected.Knockout, actual.Knockout);
            Assert.AreEqual(expected.Passes, actual.Passes);
            Assert.AreEqual(expected.Strength, actual.Strength);
            Assert.AreEqual(expected.Angle, actual.Angle);
            Assert.AreEqual(expected.Distance, actual.Distance);
        }

        public static void AreEqual(ColorMatrixFilter expected, ColorMatrixFilter actual, string message) {
            Assert.AreEqual(expected.R0, actual.R0);
            Assert.AreEqual(expected.R1, actual.R1);
            Assert.AreEqual(expected.R2, actual.R2);
            Assert.AreEqual(expected.R3, actual.R3);
            Assert.AreEqual(expected.R4, actual.R4);

            Assert.AreEqual(expected.G0, actual.G0);
            Assert.AreEqual(expected.G1, actual.G1);
            Assert.AreEqual(expected.G2, actual.G2);
            Assert.AreEqual(expected.G3, actual.G3);
            Assert.AreEqual(expected.G4, actual.G4);

            Assert.AreEqual(expected.B0, actual.B0);
            Assert.AreEqual(expected.B1, actual.B1);
            Assert.AreEqual(expected.B2, actual.B2);
            Assert.AreEqual(expected.B3, actual.B3);
            Assert.AreEqual(expected.B4, actual.B4);

            Assert.AreEqual(expected.A0, actual.A0);
            Assert.AreEqual(expected.A1, actual.A1);
            Assert.AreEqual(expected.A2, actual.A2);
            Assert.AreEqual(expected.A3, actual.A3);
            Assert.AreEqual(expected.A4, actual.A4);
        }

        public static void AreEqual(BaseFilter expected, BaseFilter actual, string message) {
            Assert.AreEqual(expected.Type, actual.Type);
            switch (expected.Type) {
                case FilterType.DropShadow:
                    AreEqual((DropShadowFilter)expected, (DropShadowFilter)actual, message);
                    break;
                case FilterType.Blur:
                    AreEqual((BlurFilter)expected, (BlurFilter)actual, message);
                    break;
                case FilterType.Glow:
                    AreEqual((GlowFilter)expected, (GlowFilter)actual, message);
                    break;
                case FilterType.Bevel:
                    AreEqual((BevelFilter)expected, (BevelFilter)actual, message);
                    break;
                case FilterType.GradientGlow:
                    AreEqual((GradientGlowFilter)expected, (GradientGlowFilter)actual, message);
                    break;
                case FilterType.Convolution:
                    AreEqual((ConvolutionFilter)expected, (ConvolutionFilter)actual, message);
                    break;
                case FilterType.ColorMatrix:
                    AreEqual((ColorMatrixFilter)expected, (ColorMatrixFilter)actual, message);
                    break;
                case FilterType.GradientBevel:
                    AreEqual((GradientBevelFilter)expected, (GradientBevelFilter)actual, message);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public static void AreEqual(IList<BaseFilter> expected, IList<BaseFilter> actual, string message) {
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], message + "[" + i + "]");
            }
        }
    }
}
