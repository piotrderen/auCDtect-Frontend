using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.fileName = Path.GetFileName(file);
        }

        public override string FormatResult()
        {
            return fileName + " => " + MPEG + " [" + percentOfConfidence + "]" + Environment.NewLine;
        }
        public override Color TextColor => textColor;
    }
}
