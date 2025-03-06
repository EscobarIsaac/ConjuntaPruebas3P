using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
namespace EjemploMVC.Reports
{
    public class ExtentReportManager
    {
        private static ExtentReports _Extent;
        private static ExtentTest _test;
        private static string _reportPath = Path.Combine(Directory.GetCurrentDirectory(), "TestResult", "ExtentReport.html");

        public static void InitReport()
        {
            var sparkReport = new ExtentSparkReporter(_reportPath);

            _Extent = new ExtentReports();

            _Extent.AttachReporter(sparkReport);
        }

        public static void StartTest(string testName)
        {
            _test = _Extent.CreateTest(testName);
        }

        public static void LogStep(bool isSuccess, string stepDetails)
        {
            if (isSuccess)
                _test.Log(Status.Pass, stepDetails);
            else
                _test.Log(Status.Fail, stepDetails);
        }

        public static void FlushReport()
        {
            _Extent.Flush();
        }
    }
}