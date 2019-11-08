using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_5
{
	public class Builder
	{
		private List<Symbol> _allSymbols = new List<Symbol>();

		public void AddLine(string line)
		{
			ValidateLine(line);

			Symbol baseSymbol = GetSymbol(line[0]);

			for (int i = 2; i < line.Length; i += 2) {
				baseSymbol.AddDependency(GetSymbol(line[i]));
			}
		}

		private void ValidateLine(string line)
		{
			if (line == null || line.Length == 0) throw new ArgumentException("Invalid line.");
			for (int i = 1; i < line.Length; i += 2) {
				if (!char.IsWhiteSpace(line[i])) throw new ArgumentException("Every other symbol is not a whitespace.");
			}
			for (int i = 0; i < line.Length; i += 2) {
				if (!char.IsLetterOrDigit(line[i])) throw new ArgumentException($"The {line[i]} symbol is not a digit or letter.");
			}
		}

		private Symbol GetSymbol(char symbolChar)
		{
			var foundSymbol = FindExistingSymbol(symbolChar);
			if (foundSymbol != null) return foundSymbol;
			else {
				var newSymbol = new Symbol(symbolChar);
				_allSymbols.Add(newSymbol);
				return newSymbol;
			}
		}

		private Symbol FindExistingSymbol(char symbolChar)
		{
			return _allSymbols.Find(x => x.representation == symbolChar);
		}

		public string PrintTransientDependencies()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var symbol in _allSymbols) {
				sb.Append(symbol).Append('\n');
			}
			return sb.ToString();
		}
	}
}
