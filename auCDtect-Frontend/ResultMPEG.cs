using System;
using System.Drawing;

namespace auCDtect_Frontend
{
    public class ResultMPEG : AnalyzeResult
    {
        private readonly Color textColor = Color.Red;
        private readonly string percentOfConfidence;
        private readonly string MPEG = "MPEG";

        public ResultMPEG(string file, string percentOfConfidence)
        {
            this.percentOfConfidence = percentOfConfidence;
            base.fileName = file;
        }

        public override string FormatResult()
        {
            return fileName + " => " + MPEG + " [" + percentOfConfidence + "]" + Environment.NewLine;
        }
        public override Color TextColor => textColor;
    }
}
