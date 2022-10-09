using System.Drawing;

namespace auCDtect_Frontend
{
    public abstract class AnalyzeResult
    {
        protected string fileName;
        public abstract string FormatResult();
        public abstract Color TextColor { get; }
    }
}
