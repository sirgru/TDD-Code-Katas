using System;

// Don't test a trivial method.
// When being paranoid to test trivial methods,
// even a mock can be considered untested, 
// and thus no test using a mock can be trusted.
// Your job in IO methods is to hand off data 
// as close to IO as possible.
namespace Kata_2
{
	public interface ILogger
	{
		void Log(string output);
	}

	public interface IWebService
	{
		void Notify(string message);
	}

	public class Logger : ILogger
	{
		public void Log(string received)
		{
			Console.WriteLine("Logging result: " + received);
		}
	}

	public class WebService : IWebService
	{
		public void Notify(string output)
		{
			Console.WriteLine("Web service received:" + output);
		}
	}
}