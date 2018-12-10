using System;
using System.Collections.Generic;
using RegressionFailureTracking.Models.ViewModels;
using RegressionFailureTracking.Services.Mappers;
using RegressionFailureTracking.Services.DbHelpers;
using RegressionFailureTracking.Models;
using System.Linq;

namespace RegressionFailureTracking.Services
{
    public class BuildSummaryService
    {
        private readonly RegressionReportService _regressionReportService;

        public BuildSummaryService()
        {
            _regressionReportService = new RegressionReportService();
        }

        public BuildSummaryViewModel GetViewModel()
        {
            var dataFromDataBase = _regressionReportService.GetBuildSummaryReport(DateTime.Now);

            var vm = new BuildSummaryViewModel();
            if (dataFromDataBase.Count > 0)
            {
                vm.TotalBuild = dataFromDataBase[0].Total;
                vm.PassBuild = dataFromDataBase[0].Passed;
                vm.FailedBuild = dataFromDataBase[0].Failed;
                vm.Stability = StabilityCaculation();
                vm.FailureBreakdown = GetFailureBreakdown();
                
            }
            return vm;
        }

        public double StabilityCaculation()
        {
            var dataFromDataBase = _regressionReportService.GetBuildSummaryReport(DateTime.Now);
            int value_pass = dataFromDataBase[0].Passed;
            int value_total = dataFromDataBase[0].Total;

            double value_stability = ((double)value_pass / (double)value_total)*100;

            return value_stability;
        }

        private IEnumerable<string> GetFailureBreakdown()
        {
            // TODO : write logic to get this number from data source
            return new List<string>()
            {
                "environment 50% (MOCK)",
                "flaky test 25% (MOCK)",
                "slowness 25% (MOCK)",
            };
        }
    }
}
