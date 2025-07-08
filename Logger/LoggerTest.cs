using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static velocist.Services.Log.StaticLoggerFactory;

namespace GenericTestProject.Logger {
	[TestClass()]
	public class LoggerTest {

		ILogger Logger { get; set; }

		public LoggerTest() {
			Logger = GetStaticLogger<LoggerTest>();
		}

		[TestMethod()]
		public void LogTraceTest() => Logger.LogTrace("Log in TRACE");

		[TestMethod()]
		public void LogDebugTest() => Logger.LogDebug("Log in DEBUG");

		[TestMethod()]
		public void LogErrorTest() => Logger.LogError("Log in ERROR");

		[TestMethod()]
		public void LogInformationTest() => Logger.LogInformation("Log in INFORMATION");

		[TestMethod()]
		public void LogWarningTest() => Logger.LogWarning("Log in WARNING");

		[TestMethod()]
		public void LogCriticalTest() => Logger.LogCritical("Log in CRITICAL");
	}
}
