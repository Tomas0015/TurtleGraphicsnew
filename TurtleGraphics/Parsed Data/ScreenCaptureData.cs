﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace TurtleGraphics
{
    public class ScreenCaptureData : ParsedData
    {

        public ScreenCaptureData(string[] parameters, string originalLine, Dictionary<string, object> variables)
            : base(variables, originalLine, parameters)
        {

        }

        public override bool IsBlock => false;

        public override string Line { get; set; }

        public override ParsedAction Action => ParsedAction.ScreenCapture;

        public override TurtleData Compile(CancellationToken token)
        {
            return new TurtleData() { Action = Action };
        }

        public override IList<TurtleData> CompileBlock(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
