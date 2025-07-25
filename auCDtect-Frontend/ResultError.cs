using System;
using System.Drawing;

namespace auCDtect_Frontend
{
    public class ResultError : AnalyzeResult
    {
        private static Color textColor = Color.Red;
        private string errorMessage;

        public ResultError(string file, string errorMassage)
        {
            this.errorMessage = errorMassage;
            base.fileName = file;
        }
        public override string FormatResult()
        {
            return fileName + " => Error: " + errorMessage + Environment.NewLine;
        }
        public override Color TextColor => textColor;
    }
}
