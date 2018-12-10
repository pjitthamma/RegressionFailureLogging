using System;
using System.Web.Mvc;
using RegressionFailureTracking.Services;
using RegressionFailureTracking.Services.DbHelpers;
using RegressionFailureTracking.Models.SearchCriteria;
using System.Collections.Generic;
using RegressionFailureTracking.Models;

namespace RegressionFailureTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbHelper _dbHelper;
        private readonly BuildSummaryService _buildSummaryService;
        private readonly RegressionReportService _regressionReportService;
        
        public HomeController()
        {
            _dbHelper = new DbHelper();
            _buildSummaryService = new BuildSummaryService();
            _regressionReportService = new RegressionReportService();
        }

        // Dialy summary page
        public ActionResult Index()
        {
            var vm = _regressionReportService.GetViewModelFailure();
            return View(vm);
        }

        // Build Summary
        public ActionResult Index2()
        {
            var vm = _buildSummaryService.GetViewModel();
            return View(vm);
        }

        #region Ajax
        [HttpPost]
        public JsonResult FetchReport(SearchCriteria criteria)
        {
            var report = new List<FailureReport>();

            if (criteria != null)
            {
                var date = new DateTime(criteria.Year, criteria.Month, criteria.Date);
                report = _regressionReportService.GetFailureReport(date);
            }

            return Json(report);
        }

        [HttpPost]
        public string UpdateReport(List<SlimFailureReport> data)
        {
            if (data == null || data.Count < 1) { return "Invalid arguments"; }
            return _dbHelper.UpdateFailureSummaryReport(data); // todo-moch : call service instead
        }
        #endregion
    }
}