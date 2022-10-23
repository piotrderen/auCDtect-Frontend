using System;
using System.Drawing;
using System.IO;

namespace auCDtect_Frontend
{
    public class ResultUnknown : AnalyzeResult
    {
        private readonly Color textColor = Color.Blue;

        public ResultUnknown(string file)
        {
            fileName = file;
        }

        public override string FormatResult()
        {
            return fileName + " => Unknown source" + Environment.NewLine;
        }
        public override Color TextColor => textColor;
    }
}
