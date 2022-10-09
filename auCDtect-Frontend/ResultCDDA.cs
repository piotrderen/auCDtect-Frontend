using System;
using System.Drawing;
using System.IO;

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
            this.fileName = Path.GetFileName(file);
        }

        public override string FormatResult()
        {
            return fileName + " => " + CDDA + " [" + percentOfConfidence + "]" + Environment.NewLine;
        }

        public override Color TextColor => textColor;
    }
}
