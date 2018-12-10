
using System;

namespace RegressionFailureTracking.Models.Dto
{
    public class FailureReportDto
    {

        public FailureReportDto(int id, string testCase, string rgNumber, DateTime time, string category, string comment, string detail, string testReport)
        {
            this.RecordId = id;
            this.TestCase = testCase;
            this.RgNumber = rgNumber;
            this.Time = time;
            this.Category = category;
            this.Comment = comment;
            this.Detail = detail;
            this.TestReport = testReport;
        }

        public int RecordId { get; set; }
        public string TestCase { get; set; }
        public string RgNumber { get; set; }
        public DateTime Time { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public string Detail { get; set; }
        public string TestReport { get; set; }
        public string Hash
        {
            get
            {
                int hash = 123;

                hash += TestCase?.GetHashCode() ?? 0;
                hash += RgNumber?.GetHashCode() ?? 0;
                hash += (Time != null) ? Time.GetHashCode() : 0;
                hash += Category?.GetHashCode() ?? 0;
                hash += Comment?.GetHashCode() ?? 0;
                hash += Detail?.GetHashCode() ?? 0;
                hash += TestReport?.GetHashCode() ?? 0;

                return hash.ToString();
            }
        }
    }
}