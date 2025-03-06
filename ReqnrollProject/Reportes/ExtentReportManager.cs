using AventStack.ExtentReports;

using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Reportes
{
    public class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportPath = Path.Combine(Directory.GetCurrentDirectory(), "TestResult", "AfterTestRun");

        public static void InitReport()
        {
            var sparkReport = new ExtentSparkReporter(_reportPath);
            _extent = new ExtentReports();

            _extent.AttachReporter(sparkReport);
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);

        }

        public static void LogStep(bool isSuccess, string stepDetail)
        {
            if (isSuccess)
                _test.Log(Status.Pass, stepDetail);
            else
                _test.Log(Status.Fail, stepDetail);
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
