using System;
using System.Data.SQLite;
using System.Collections.Generic;
using RegressionFailureTracking.Models.Dto;
using RegressionFailureTracking.Models;
using Agoda.Automata.DB;
using System.Data;
using System.Text.RegularExpressions;

namespace RegressionFailureTracking.Services.DbHelpers
{
    // To be nice, should have repository layer instead of this helper
    public class DbHelper
    {
        // TODO : move to query string
        private readonly DatabaseManager _dbManager;
        private static readonly string SEVER_NAME = "###SERVERNAME###";
        private static readonly string DB_NAME = "###DBNAME###";
        private static readonly string USERNAME = "###USERNAME###";
        private static readonly string PASSWORD = "###PASSWORD###";

        // TODO : move to Storeprocedure
        private static readonly string DATE_FORMAT = "yyyy-MM-dd";
        private static readonly string SELECT_FAILURE_WITHDATE_CONDITION = "###QUERY###";
        private static readonly string SELECT_SUMMARY_WITHDATE_CONDITION = "###QUERY###";

        public DbHelper()
        {
            _dbManager = new DatabaseManager(SEVER_NAME, DB_NAME, USERNAME, PASSWORD);
        }

        public List<FailureReportDto> FetchFailureSummaryReport(DateTime date)
        {
            return FetchFailureSummaryFromSQL(date);
        }
        public List<BuildSummaryReportDto> FetchBuildSummaryReport(DateTime date)
        {
            return FetchBuildSummaryFromSQL(date);
        }

        //public void InsertFailureToDatabase(List<FailureReportDto> dataList)
        //{
        //    try
        //    {
        //        ConnectDatabase();

        //        foreach (var data in dataList)
        //        {
        //            if (!string.IsNullOrEmpty(data.Details))
        //            {
        //                Details = StripHTML(data.Details);
        //            }
        //            if (!string.IsNullOrEmpty(data.LogMessages))
        //            {
        //                Logmessages = StripHTML(data.LogMessages);
        //            }
        //            if (string.IsNullOrEmpty(data.Details))
        //            {
        //                Details = data.Details;
        //            }
        //            if (string.IsNullOrEmpty(data.LogMessages))
        //            {
        //                Logmessages = data.LogMessages;
        //            }

        //            var failure_data_list_insert = string.Format(###QUERY###);

        //            //Send to DB
        //            _dbManager.Query(failure_data_list_insert);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        public string UpdateFailureSummaryReport(List<SlimFailureReport> dataList)
        {
            var status = "Success";

            try
            {
                ConnectDatabase();
                DataTable ResultTableName = null;

                foreach (var data in dataList)
                {
                    // Read all records from 
                    var update_daily_data = "###QUERY###";

                    //Send to DB
                    ResultTableName = _dbManager.Query(update_daily_data);
                }
            }
            catch (Exception ex)
            {
                status = ex.ToString();
            }

            return status;
        }

        public string UpdateSummaryReport(List<SlimSummaryReport> dataList)
        {
            var status = "Success";

            try
            {
                ConnectDatabase();
                DataTable ResultTableName = null;

                foreach (var data in dataList)
                {
                    // Read all records from 
                    var update_daily_data = "###QUERY###";

                    //Send to DB
                    ResultTableName = _dbManager.Query(update_daily_data);
                }
            }
            catch (Exception ex)
            {
                status = ex.ToString();
            }

            return status;
        }

        private List<FailureReportDto> FetchFailureSummaryFromSQL(DateTime time)
        {
            // QL
            var queryDate = time.ToString(DATE_FORMAT);
            var tomorrowDate = time.AddDays(1).ToString(DATE_FORMAT);
            var fechting_daily_data = string.Format(SELECT_FAILURE_WITHDATE_CONDITION, queryDate, tomorrowDate);

            // Execute DB
            ConnectDatabase();
            DataTable ResultTableName = _dbManager.Query(fechting_daily_data);

            // Read data
            List<FailureReportDto> failureSummaryReport = new List<FailureReportDto>();
            if (ResultTableName != null && ResultTableName.Rows != null && ResultTableName.Rows.Count > 0)
            {
                foreach (DataRow dtRow in ResultTableName.Rows)
                {
                    failureSummaryReport.Add(new FailureReportDto((int)dtRow["ID"]);
                }
            }

            return failureSummaryReport;
        }

        private List<BuildSummaryReportDto> FetchBuildSummaryFromSQL(DateTime time)
        {
            // QL
            var queryDate = time.ToString(DATE_FORMAT);
            var tomorrowDate = time.AddDays(1).ToString(DATE_FORMAT);
            var fechting_summary_data = string.Format(SELECT_SUMMARY_WITHDATE_CONDITION, queryDate, tomorrowDate);

            // Execute DB
            ConnectDatabase();
            DataTable ResultTableName = _dbManager.Query(fechting_summary_data);

            // Read data
            List<BuildSummaryReportDto> buildSummaryReport = new List<BuildSummaryReportDto>();
            if (ResultTableName != null && ResultTableName.Rows != null && ResultTableName.Rows.Count > 0)
            {
                foreach (DataRow dtRow in ResultTableName.Rows)
                {
                    buildSummaryReport.Add(new BuildSummaryReportDto((int)dtRow["ID"]);
                }
            }

            return buildSummaryReport;
        }

        #region Private Method
        public void ConnectDatabase()
        {
            _dbManager.Connect();
        }

        public string StripHTML(string input)
        {
            return Regex.Replace(input, "'", String.Empty);
        }
        #endregion
    }
}