using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auCDtect_Frontend
{
    public class ResultError : AnalyzeResult
    {
        private static Color textColor = Color.Red;
        private string errorMessage;

        public ResultError(string file, string errorMassage)
        {
            this.errorMessage = errorMassage;
            this.fileName = file;
        }
        public override string FormatResult()
        {
            return fileName + " => Error: " + errorMessage + Environment.NewLine;
        }
        public override Color TextColor => textColor;
    }
}
