using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_4
{
	public class RomanNumerals
	{
		private static Dictionary<char, int> _rom2Num = new Dictionary<char, int>{
			['I'] = 1, ['V'] = 5, ['X'] = 10, ['L'] = 50, ['C'] = 100, ['D'] = 500, ['M'] = 1000,
		};

		private static Dictionary<int, string> _num2Roman1 = new Dictionary<int, string>{
			[1] = "I", [2] = "II", [3] = "III", [4] = "IV", [5] = "V", [6] = "VI", [7] = "VII", [8] = "VIII", [9] = "IX"
		};
		private static Dictionary<int, string> _num2Roman10 = new Dictionary<int, string>{
			[1] = "X", [2] = "XX", [3] = "XXX", [4] = "XL", [5] = "L", [6] = "LX", [7] = "LXX", [8] = "LXXX", [9] = "XC"
		};
		private static Dictionary<int, string> _num2Roman100 = new Dictionary<int, string>{
			[1] = "C", [2] = "CC", [3] = "CCC", [4] = "CD", [5] = "D", [6] = "DC", [7] = "DCC", [8] = "DCCC", [9] = "CM"
		};

		public static int Evaluate(string input)
		{
			if (input == null || input.Length == 0) return 0;

			int sum = 0;
			int previousValue = _rom2Num[ input[0] ];
			int currentValue = 0;

			for (int i = 1; i < input.Length; i++) {
				currentValue = _rom2Num[input[i]];

				if (currentValue > previousValue) {
					currentValue -= previousValue;
				}
				else {
					sum += previousValue;
				}

				previousValue = currentValue;
			}

			return sum + currentValue;
		}

		public static string Convert(int number)
		{
			if (number <= 0 || number > 3000) throw new ArgumentOutOfRangeException("Only supporting numbers from 1 to 3000.");

			StringBuilder sb = new StringBuilder();

			if (number >= 1000) {
				int thousands = number / 1000;
				number %= 1000;
				sb.Append('M', thousands);
			}

			if (number >= 100) {
				int hundreds = number / 100;
				number %= 100;
				sb.Append(_num2Roman100[hundreds]);
			}

			if (number >= 10) {
				int tens = number / 10;
				number %= 10;
				sb.Append(_num2Roman10[tens]);
			}

			sb.Append(_num2Roman1[number]);

			return sb.ToString();
		}
	}
}
