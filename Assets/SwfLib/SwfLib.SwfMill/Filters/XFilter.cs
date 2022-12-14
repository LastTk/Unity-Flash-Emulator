﻿using System;
using System.Xml.Linq;
using SwfLib.Filters;

namespace SwfLib.SwfMill.Filters {
    /// <summary>
    /// Represents filters xml formatter.
    /// </summary>
    public static class XFilter {

        private class Writer : IFilterVisitor<object, XElement> {

            public XElement Visit(DropShadowFilter filter, object arg) {
                return XDropShadowFilter.ToXml(filter);
            }

            public XElement Visit(BlurFilter filter, object arg) {
                return XBlurFilter.ToXml(filter);
            }

            public XElement Visit(GlowFilter filter, object arg) {
                return XGlowFilter.ToXml(filter);
            }

            public XElement Visit(BevelFilter filter, object arg) {
                return XBevelFilter.ToXml(filter);
            }

            public XElement Visit(GradientGlowFilter filter, object arg) {
                return XGradientGlowFilter.ToXml(filter);
            }

            public XElement Visit(ConvolutionFilter filter, object arg) {
                return XConvolutionFilter.ToXml(filter);
            }

            public XElement Visit(ColorMatrixFilter filter, object arg) {
                return XColorMatrixFilter.ToXml(filter);
            }

            public XElement Visit(GradientBevelFilter filter, object arg) {
                return XGradientBevelFilter.ToXml(filter);
            }
        }

        private static readonly Writer _writer = new Writer();

        /// <summary>
        /// Formats filter to xml representation..
        /// </summary>
        /// <param name="filter">The filter to be formatted.</param>
        /// <returns></returns>
        public static XElement ToXml(BaseFilter filter) {
            return filter.AcceptVisitor(_writer, null);
        }

        /// <summary>
        /// Parses filter from xml.
        /// </summary>
        /// <param name="xFilter">Xml element to be parsed.</param>
        /// <returns></returns>
        public static BaseFilter FromXml(XElement xFilter) {
            switch (xFilter.Name.LocalName) {
                case XDropShadowFilter.TAG_NAME:
                    return XDropShadowFilter.FromXml(xFilter);
                case XBlurFilter.TAG_NAME:
                    return XBlurFilter.FromXml(xFilter);
                case XGlowFilter.TAG_NAME:
                    return XGlowFilter.FromXml(xFilter);
                case XBevelFilter.TAG_NAME:
                    return XBevelFilter.FromXml(xFilter);
                case XGradientGlowFilter.TAG_NAME:
                    return XGradientGlowFilter.FromXml(xFilter);
                case XConvolutionFilter.TAG_NAME:
                    return XConvolutionFilter.FromXml(xFilter);
                case XColorMatrixFilter.TAG_NAME:
                    return XColorMatrixFilter.FromXml(xFilter);
                case XGradientBevelFilter.TAG_NAME:
                    return XGradientBevelFilter.FromXml(xFilter);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
