using System;
using System.Drawing;

namespace auCDtect_Frontend
{
    public class ResultCDDA : AnalyzeResult
    {
        private readonly Color textColor = Color.Green;
        private readonly string percentOfConfidence;
        private readonly string CDDA = "CDDA";

        public ResultCDDA(string file, string percentOfConfidence)
        {
            this.percentOfConfidence = percentOfConfidence;
            base.fileName = file;
        }

        public override string FormatResult()
        {
            return fileName + " => " + CDDA + " [" + percentOfConfidence + "]" + Environment.NewLine;
        }

        public override Color TextColor => textColor;
    }
}
