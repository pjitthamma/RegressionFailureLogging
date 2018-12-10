
using System.Collections.Generic;

namespace RegressionFailureTracking.Models.ViewModels
{
    public class RegressionReportViewModel
    {
        public List<FailureReport> FailureReports { get; set; }
        public List<BuildSummaryReport> SummaryReports { get; set; }
    }
}