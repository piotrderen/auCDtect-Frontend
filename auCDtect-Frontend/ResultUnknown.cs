using System;
using System.Drawing;

namespace auCDtect_Frontend
{
    public class ResultUnknown : AnalyzeResult
    {
        private readonly Color textColor = Color.Blue;

        public ResultUnknown(string file)
        {
            base.fileName = file;
        }

        public override string FormatResult()
        {
            return fileName + " => Unknown source" + Environment.NewLine;
        }
        public override Color TextColor => textColor;
    }
}
