using System.Collections.Generic;
using RegressionFailureTracking.Models;
using RegressionFailureTracking.Models.Dto;

namespace RegressionFailureTracking.Services.Mappers
{
    public class RegressionFailureReportMapper
    {
        private static readonly int MAXIMUM_CHAR_INLOG = 140;

        public void MapTo(List<FailureReportDto> dbData, List<FailureReport> ourModel)
        {
            if (dbData == null || dbData.Count < 1 || ourModel == null) { return; }

            // Loop through dtatabase results and map to our model
            foreach (var data in dbData)
            {
                var failureReport = new FailureReport()
                {
                    RecordId = data.RecordId,
                    TestCase = data.TestCase,
                    RgNumber = data.RgNumber,
                    RgValue = BuildRgValue(data.RgNumber),
                    Time = data.Time,
                    Category = data.Category,
                    Comment = data.Comment,
                    Details = BuildMessages(data.Detail),
                    TestReport = data.TestReport,
                };

                ourModel.Add(failureReport);
            }
        }

        private Message BuildMessages(string original)
        {
            var isOverflow = original.Length > MAXIMUM_CHAR_INLOG;

            return new Message()
            {
                IsOverflow = original.Length > MAXIMUM_CHAR_INLOG,
                MainMessage = (isOverflow) ? original.Substring(0, MAXIMUM_CHAR_INLOG) : original,
                OverflowMessage = (isOverflow) ? original.Substring(MAXIMUM_CHAR_INLOG) : "",
            };
        }

        private int BuildRgValue(string rgText)
        {
            var rgValue = 0;
            if (string.IsNullOrWhiteSpace(rgText) || !rgText.Contains("-Schedule Trigger")) { return rgValue; }

            var pivot = rgText.LastIndexOf('-') + 1;
            string onlyNumberText = rgText.Substring(pivot, rgText.Length - pivot);
            int.TryParse(onlyNumberText, out rgValue);

            return rgValue;
        }
    }
}