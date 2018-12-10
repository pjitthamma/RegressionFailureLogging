
using System.Collections.Generic;
using RegressionFailureTracking.Models.Dto;
using System.IO;
using Newtonsoft.Json;

namespace RegressionFailureTracking.Services.JsonHelpers
{
    public class JsonHelper
    {
        private static readonly string REGRESSION_FAILURE_PATH = "###JSONPATH###";

        // Get data from JSON file
        public List<FailureReportDto> GetFailureSummaryFromJson()
        {
            var json = ReadJsonFile(REGRESSION_FAILURE_PATH);
            var failureResults = JsonConvert.DeserializeObject<List<FailureReportDto>>(json);
            return failureResults;
        }

        private string ReadJsonFile(string path)
        {
            string json = "";

            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }

            return json;
        }
    }
}