using System;

namespace RegressionFailureTracking.Models
{
    public class BuildSummaryReport
    {
        public int RecordId { get; set; }
        public DateTime Time { get; set; }
        public int Total { get; set; }
        public int Failed { get; set; }
        public int Passed { get; set; }
        public int Stability { get; set; }
    }

    // use for update data in table
    public class SlimSummaryReport
    {
        public int RecordId { get; set; }
        public int Total { get; set; }
        public int Failed { get; set; }
        public int Passed { get; set; }
        public int Stability { get; set; }
    }
}