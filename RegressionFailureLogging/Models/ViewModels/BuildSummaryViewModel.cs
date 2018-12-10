using System.Collections.Generic;

namespace RegressionFailureTracking.Models.ViewModels
{
    public class BuildSummaryViewModel
    {
        public int TotalBuild { get; set; }
        public int PassBuild { get; set; }
        public int FailedBuild { get; set; }
        public double Stability { get; set; }
        public IEnumerable<string> FailureBreakdown { get; set; }
    }
}
