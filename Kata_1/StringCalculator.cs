using Kata_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_1
{
	public class StringCalculator
	{
		private static readonly string _defaultDelimiter = ",";

		private int _calledCount;
		public int calledCount => _calledCount;
		public event Action<string, int> addOccured;

		private ILogger _logger;
		private IWebService _webService;

		public StringCalculator(ILogger logger = null, IWebService webService = null)
		{
			if (logger == null) _logger = new Logger();
			else _logger = logger;
			if (webService == null) _webService = new WebService();
			else _webService = webService;
		}

		public int Add(string input)
		{
			_calledCount++;

			int result = 0;
			try {
				result = AddBody(input);
			}
			catch (Exception ex) {
				_webService.Notify(ex.Message);
				throw;
			}

			addOccured?.Invoke(input, result);
			_logger.Log(result.ToString());

			return result;
		}

		private int AddBody(string input)
		{
			if (input == null || input.Length == 0) return 0;

			var (newInput, customDelimiters) = GetCustomDelimiter(input);

			int result = 0;

			var numbersStr = GetSeparatedNumbers(newInput, customDelimiters);

			List<int> negatives = new List<int>();
			foreach (var ns in numbersStr) {
				if (ns.Trim() == "") continue;

				if (int.TryParse(ns, out int numberInt)) {
					if (numberInt < 0) {
						negatives.Add(numberInt);
					}
					else if (numberInt > 1000) numberInt = 0;
					result += numberInt;
				}
				else throw new InputException("Not a valid number.");
			}

			if (negatives.Count > 0) {
				string message = "";
				foreach (var n in negatives) {
					message += n.ToString() + " ";
				}
				throw new InputException("Negatives not allowed: " + message);
			}

			return result;
		}

		private (string newInput, string[] delimiter) GetCustomDelimiter(string input)
		{
			if (input.StartsWith("//")) {
				if (input[2] != '[') {
					var delimiterIndex = input.IndexOf('\n');
					if (delimiterIndex == -1) throw new InputException("Not properly delimited");
					var newInput = input.Substring(delimiterIndex + 1);
					var delimiter = new[] { input.Substring(2, delimiterIndex - 2)};
					return (newInput, delimiter);
				}

				for (int i = 2; i < input.Length; i++) {
					if (input[i] == '\n' && input[i-1] == ']') {
						var newInput = input.Substring(i + 1);
						var delimitersWithoutBrackets = input.Substring(3, i - 4);
						var delimiters = GetDelimitersComplex(delimitersWithoutBrackets);
						return (newInput, delimiters);
					} 
				}
				throw new InputException("Not delimited properly");
			}
			else return (input, null);
		}

		private string[] GetDelimitersComplex(string input)
		{
			return input.Split("][");
		}

		private List<string> GetSeparatedNumbers(string input, string[] customDelimiters)
		{
			if (customDelimiters != null) {
				foreach (var delimiter in customDelimiters) {
					if (delimiter.Length == 0) throw new InputException("Delimiter cannot be of zero length.");
					input = input.Replace(delimiter, ",");
				}
			}
			input = input.Replace('\n', ',');
			return input.Split(',').ToList();
		}
	}
}
