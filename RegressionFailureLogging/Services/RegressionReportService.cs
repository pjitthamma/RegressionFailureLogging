using System;
using System.Linq;
using System.Collections.Generic;
using RegressionFailureTracking.Models;
using RegressionFailureTracking.Models.ViewModels;
using RegressionFailureTracking.Services.Mappers;
using RegressionFailureTracking.Services.DbHelpers;

namespace RegressionFailureTracking.Services
{
    public class RegressionReportService
    {
        #region Properties
        private readonly DbHelper _dbHelper;
        private readonly RegressionFailureReportMapper _failureReportMapper;
        private readonly RegressionBuildReportMapper _buildReportMapper;
        #endregion

        public RegressionReportService()
        {
            _dbHelper = new DbHelper();
            _failureReportMapper = new RegressionFailureReportMapper();
            _buildReportMapper = new RegressionBuildReportMapper();
        }

        public RegressionReportViewModel GetViewModelFailure()
        {
            var vm = new RegressionReportViewModel();

            vm.FailureReports = GetFailureReport(DateTime.Now);

            return vm;
        }

        public RegressionReportViewModel GetViewModelBuildSummary()
        {
            var vm = new RegressionReportViewModel();

            vm.SummaryReports = GetBuildSummaryReport(DateTime.Now);

            return vm;
        }

        public List<FailureReport> GetFailureReport(DateTime date)
        {
            //1) Read data from Database (table : FailureDataReport)
            var failureDbResults = _dbHelper.FetchFailureSummaryReport(date);

            //2) Map data from database to our model
           var failureReports = new List<FailureReport>();
            _failureReportMapper.MapTo(failureDbResults, failureReports);

            //3) Sort by releasegroup
            return failureReports.OrderBy(x => x.Time).ToList();
        }

        public List<BuildSummaryReport> GetBuildSummaryReport(DateTime date)
        {
            //1) Read data from Database (table : FailureDataReport)
            var summaryDbResults = _dbHelper.FetchBuildSummaryReport(date);

            //2) Map data from database to our model
            var summaryReports = new List<BuildSummaryReport>();
            _buildReportMapper.MapTo(summaryDbResults, summaryReports);

            return summaryReports;
        }
    }
}