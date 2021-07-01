using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auCDtect_Frontend
{
    class AnalyzeResult
    {
        public string AudioFormat { get; set; }
        public string PercentOfConfidence { get; set; }
        public string ErrorMessage { get; set; }
        public bool Error { get => !string.IsNullOrEmpty(ErrorMessage); }
    }
}

