using System;

namespace RegressionFailureTracking.Models
{
    public class FailureReport
    {
        public int RecordId { get; set; }
        public string TestCase { get; set; }
        public string RgNumber { get; set; }
        public int RgValue { get; set; }
        public DateTime Time { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public Message Details { get; set; }
        public string TestReport { get; set; }
        public string TimeString
        {
            get
            {
                return (Time != null) ? Time.ToString() : "";
            }
        }
    }

    // use for update data in table
    public class SlimFailureReport
    {
        public int RecordId { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
    }
}