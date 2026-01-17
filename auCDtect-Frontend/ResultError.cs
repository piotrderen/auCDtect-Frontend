using System;
using System.Drawing;

namespace auCDtect_Frontend
{
    public class ResultError : AnalyzeResult
    {
        private readonly Color textColor = Color.Red;
        private readonly string errorMessage;

        public ResultError(string file, string errorMessage)
        {
            this.errorMessage = errorMessage;
            base.fileName = file;
        }
        public override string FormatResult()
        {
            return fileName + " => Error: " + errorMessage + Environment.NewLine;
        }
        public override Color TextColor => textColor;
    }
}
